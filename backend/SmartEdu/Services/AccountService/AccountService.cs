using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using SmartEdu.Helpers.EncoderDecoder;
using SmartEdu.Models;
using SmartEdu.Repository;
using SmartEdu.Services.AuthService;
using SmartEdu.Services.BunnyService;
using SmartEdu.Services.EmailService;
using SmartEdu.Services.SmsService;
using SmartEdu.UnitOfWork;
using System.Linq.Expressions;
using System.Security.Claims;
using X.PagedList;
using Microsoft.AspNetCore.JsonPatch;

namespace SmartEdu.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSenderService _emailSenderService;
        private readonly ClientAppOptions _clientAppConfig;
        private readonly ISmsService _smsService;
        private readonly IAuthService _authService;
        private readonly IBunnyService _bunnyService;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IEmailSenderService emailSenderService, ClientAppOptions clientAppConfig, ISmsService smsService, IAuthService authService, IBunnyService bunnyService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _emailSenderService = emailSenderService;
            _clientAppConfig = clientAppConfig;
            _smsService = smsService;
            _authService = authService;
            _bunnyService = bunnyService;
        }

        public async Task<bool> CanUserUpdateOrGetHisEntity<TEntity>(Expression<Func<TEntity, bool>> filter, GetUserDTO currentUser) where TEntity : class
        {
            var repo = (IGenericRepository<TEntity>) _unitOfWork.GetType().GetProperty($"{typeof(TEntity).Name}Repository").GetValue(_unitOfWork, null);
            var entity = await repo.GetSingle(filter);          
            if (entity is null)
            {
                return true;
            }    
            
            return false;
        }

        

        public async Task<IEnumerable<User>> GetAllUsers(RequestParams requestParams, List<string>? includes = null)
        {
            IQueryable<User> users = _userManager.Users;
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    users = users.Include(include);
                }
            }
            return await users.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);         
        }

        public async Task<GetUserDTO> GetCurrentUser()
        {
            GetUserDTO currentUser;
            IQueryable<User> query = _userManager.Users;
            try
            {
                
                var username = _httpContextAccessor.HttpContext.User.FindFirstValue("username").ToUpper(); 

                currentUser = _mapper.Map<GetUserDTO>(await query.FirstOrDefaultAsync(u => u.NormalizedUserName == username));              
            }
            catch (Exception ex)
            {
                currentUser = null;   
            }
            return currentUser;
        }

        public async Task<bool> IsAdministrator(GetUserDTO currentUser)
        {
            var identityUser = await _userManager.FindByIdAsync(currentUser.Id);
            var roles = await _userManager.GetRolesAsync(identityUser);
            return roles.Contains("Administrator");
        }      

        

        public async Task<ServerResponse<object>> CreateUserAndAddRoles(RegisterUserDTO registerUserDTO, ModelStateDictionary modelState)
        {
            var serverResponse = new ServerResponse<object>();

            if (!modelState.IsValid)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again.";
                serverResponse.Data = modelState;
                return serverResponse;
            }

            var rolesToUpper = registerUserDTO.Roles.Select(r => r.ToUpper());

            if (rolesToUpper.Count() > 1)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Only one role can be assigned to each user.";
                return serverResponse;
            }

            if (!rolesToUpper.Contains("USER") && !rolesToUpper.Contains("ADMIN"))
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = @"Roles must be either ""User"" or ""Admin""";
                return serverResponse;
            }

            var currentUser = await GetCurrentUser();

            //if (rolesToUpper.Contains("ADMINISTRATOR"))
            //{
            //    if (currentUser is null || !await IsAdministrator(currentUser))
            //    {
            //        serverResponse.Succeeded = false;
            //        serverResponse.Message = "This operation requires administrator permission.";
            //        return serverResponse;
            //    }
            //}

            var user = _mapper.Map<User>(registerUserDTO);

            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    modelState.AddModelError(err.Code, err.Description);
                }
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again.";
                serverResponse.Data = modelState;
                return serverResponse;
            }

            result = await _userManager.AddToRolesAsync(user, registerUserDTO.Roles);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    modelState.AddModelError(err.Code, err.Description);
                }
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again.";
                serverResponse.Data = modelState;
                return serverResponse;
            }

            var identityUser = await _userManager.FindByNameAsync(registerUserDTO.UserName);

            await VerifyEmail(user);

            serverResponse.Message = "Registered successfully. Please check your email for the confirmation link";

            return serverResponse;           
        }

        public async Task VerifyEmail(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var encodedToken = EncoderDecoder.Base64Encode(token);

            var confirmationLink = $"{_clientAppConfig.BaseUri}/confirm-email?token={encodedToken}&email={user.Email}";           

            var content = string.Format("<p>Hello {0}, thank you a lot for signing up for SmartEdu! Please click <a href='{1}' target='_blank' style='color: #ff4545'>this link</a> to confirm your email.</p>", user.FullName, confirmationLink);

            var email = new EmailMessage(new string[] { user.Email }, "Verify your email", content);

            await _emailSenderService.SendEmailAsync(email);
        }

        public async Task<ServerResponse<object>> ConfirmEmail(string token, string email, ModelStateDictionary modelState)
        {
            var serverResponse = new ServerResponse<object>();

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "This email is not associated with any user.";
                return serverResponse;
            }

            if (user.EmailConfirmed)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "This email had already been confirmed.";
                return serverResponse;
            }

            var decodedToken = EncoderDecoder.Base64Decode(token);
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (result.Succeeded)
            {
                serverResponse.Message = "Confirm email successfully. Now you can login to our website.";
                return serverResponse;
            }
            else
            {
                foreach (var err in result.Errors)
                {
                    modelState.AddModelError(err.Code, err.Description);
                }

                serverResponse.Succeeded = false;
                serverResponse.Message = "Token is invalid. Please check the error and try again.";
                serverResponse.Data = modelState;
                return serverResponse;
            }            
        }

        public async Task<ServerResponse<object>> VerifyPhone(VerifyPhoneUserDTO verifyPhoneUserDTO, ModelStateDictionary modelState)
        {
            var serverResponse = new ServerResponse<object>();

            if (!modelState.IsValid)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again.";
                serverResponse.Data = modelState;
                return serverResponse;
            }

            var currentUser = await GetCurrentUser();

            if (await _smsService.SendVerificationCode(verifyPhoneUserDTO, currentUser))
            {
                return serverResponse;
            }
            else
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Invalid phone number. Please check your phone number and try again.";
                return serverResponse;
            }
        }

        public async Task<ServerResponse<object>> ConfirmPhone(ConfirmPhoneUserDTO confirmPhoneUserDTO, ModelStateDictionary modelState)
        {
            var serverResponse = new ServerResponse<object>();
            if (!modelState.IsValid)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again.";
                serverResponse.Data = modelState;
                return serverResponse;
            }

            var currentUser = await GetCurrentUser();

            if (await _smsService.ConfirmVerificationCode(confirmPhoneUserDTO, currentUser))
            {
                serverResponse.Message = "Confirm phone successfully. Now you can use that phone with your account.";
            }
            else
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Invalid verification code. Please try again.";
            }
            return serverResponse;
        }

        public async Task<ServerResponse<object>> Login(LoginUserDTO loginUserDTO, ModelStateDictionary modelState)
        {
            var serverResponse = new ServerResponse<object>();

            if (!modelState.IsValid)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again";
                serverResponse.Data = modelState;
                return serverResponse;
            }

            if (!await _authService.ValidateUser(loginUserDTO))
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Invalid username or password.";
                return serverResponse;
            }

            serverResponse.Data = await _authService.CreateToken();
            return serverResponse;
        }

        public async Task<ServerResponse<object>> ForgotPassword(ForgotPasswordUserDTO forgotPasswordUserDTO, ModelStateDictionary modelState)
        {
            var serverResponse = new ServerResponse<object>();

            if (!modelState.IsValid)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again.";
                serverResponse.Data = modelState;
                return serverResponse;
            }

            var identityUser = await _userManager.FindByEmailAsync(forgotPasswordUserDTO.Email);

            if (identityUser is null)
            {
                return serverResponse;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(identityUser);

            var encodedToken = EncoderDecoder.Base64Encode(token);

            var resetLink = $"{_clientAppConfig.BaseUri}/reset-password?token={encodedToken}";

            var content = string.Format("<p>Hello there, please click <a href='{0}' target='_blank'>this link</a> to reset your password account.</p>", resetLink);

            var email = new EmailMessage(new string[] { identityUser.Email }, "Reset password link", content);

            await _emailSenderService.SendEmailAsync(email);

            return serverResponse;
        }

        public async Task<ServerResponse<object>> ResetPassword(ResetPasswordUserDTO resetPasswordUserDTO, ModelStateDictionary modelState)
        {
            var serverResponse = new ServerResponse<object>();
            if (!modelState.IsValid)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again";
                serverResponse.Data = modelState;
                return serverResponse;
            }

            var identityUser = await _userManager.FindByEmailAsync(resetPasswordUserDTO.Email);

            if (identityUser is null)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "This email is not associated with any user.";
                return serverResponse;
            }

            var result = await _userManager.ResetPasswordAsync(identityUser, resetPasswordUserDTO.Token, resetPasswordUserDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    modelState.TryAddModelError(err.Code, err.Description);
                }
                serverResponse.Succeeded = false;
                serverResponse.Message = "Invalid token. Please check the error and try again.";
                serverResponse.Data = modelState;
            }
            else
            {
                serverResponse.Message = "You have successfully reset your password.";
            }            
            return serverResponse;
        }

        public async Task<ServerResponse<object>> DeleteUser(DeleteUserDTO deleteUserDTO, ModelStateDictionary modelState)
        {
            var serverResponse = new ServerResponse<object>();
            
            if (!modelState.IsValid)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again.";
                serverResponse.Data = modelState;
                return serverResponse;
            }

            var identityUser = await _userManager.FindByNameAsync(deleteUserDTO.Username);

            if (identityUser is null || !await _userManager.CheckPasswordAsync(identityUser, deleteUserDTO.Password))
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Invalid username or password. Please try again.";
                return serverResponse;
            }
            await _userManager.DeleteAsync(identityUser);
            serverResponse.Message = "Deleted user successfully.";
            return serverResponse;
        }

        public async Task<ServerResponse<object>> UpdateUser(UpdateUserDTO updateUserDTO, ModelStateDictionary modelState)
        {
            var serverResponse = new ServerResponse<object>();

            if (!modelState.IsValid)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid. Please check the error and try again";
                serverResponse.Data = modelState;
                return serverResponse;
            }

            var identityUser = await _userManager.FindByNameAsync(updateUserDTO.UserName);
            var currentUser = await GetCurrentUser();

            if (identityUser is null)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Invalid username. Please try again";
                return serverResponse;
            }

            if (identityUser.Id != currentUser.Id && !await IsAdministrator(currentUser))
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "You are not allowed to perform this operation";              
            }
            else
            {
                _mapper.Map(updateUserDTO, identityUser);
                await _userManager.UpdateAsync(identityUser);
                serverResponse.Message = "Updated user successfully";
            }
            return serverResponse;
        }

        public async Task<ServerResponse<AuthResponseUserDTO>> GoogleLogin(GoogleAuthUserDTO googleAuthUserDTO)
        {
            var serverResponse = new ServerResponse<AuthResponseUserDTO>();
            var payload = await _authService.VerifyGoogleToken(googleAuthUserDTO);

            if (payload is null)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Invalid external authentication.";
                return serverResponse;
            }

            var info = new UserLoginInfo(googleAuthUserDTO.Provider, payload.Subject, googleAuthUserDTO.Provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);

                if (user is null)
                {
                    user = new User
                    {
                        Email = payload.Email, UserName = payload.Email
                    };

                    await _userManager.CreateAsync(user);

                    // Prepare and send an email for the confirmation link
                    await VerifyEmail(user);

                    await _userManager.AddToRolesAsync(user, new List<string> { "User" });

                    await _userManager.AddLoginAsync(user, info);
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }

            if (user is null)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Invalid external authentication.";
                return serverResponse;
            }

            _authService.User = user;
            var token = await _authService.CreateToken();
            serverResponse.Data = new AuthResponseUserDTO
            {
                Token = token,
                AuthSucceeded = true
            };
            return serverResponse;
        }

        public async Task<ServerResponse<AuthResponseUserDTO>> FacebookLogin(FacebookAuthUserDTO facebookAuthUserDTO)
        {
            var serverResponse = new ServerResponse<AuthResponseUserDTO>();

            var payload = await _authService.VerifyFacebookToken(facebookAuthUserDTO);

            if (payload is null)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Invalid external authentication.";
                return serverResponse;
            }

            var info = new UserLoginInfo(facebookAuthUserDTO.Provider, facebookAuthUserDTO.UserId, facebookAuthUserDTO.Provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);

                if (user is null)
                {
                    user = new User { Email = payload.Email, UserName = payload.Email };

                    await _userManager.CreateAsync(user);

                    // Prepare and send an email for the confirmation link
                    await VerifyEmail(user);

                    await _userManager.AddToRolesAsync(user, new List<string> { "User" });

                    await _userManager.AddLoginAsync(user, info);
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }

            if (user is null)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Invalid external authentication.";
                return serverResponse;
            }

            _authService.User = user;
            var token = await _authService.CreateToken();
            serverResponse.Data = new AuthResponseUserDTO
            {
                Token = token,
                AuthSucceeded = true
            };
            return serverResponse;
        }

        public async Task<ServerResponse<GetUserDTO>> UpdateProfileImage(MultipleFilesModel model, ModelStateDictionary modelState)
        {
            var currentUser = await GetCurrentUser();
            var serverResponse = new ServerResponse<GetUserDTO>();
            var response = await _bunnyService.UploadFiles(model, "account", currentUser.UserName, modelState);
            if (response.Data is not null)
            {
                
                var identityUser = await _userManager.FindByIdAsync(currentUser.Id);
                identityUser.ProfileImage = response.Data.ElementAt(0);
                await _userManager.UpdateAsync(identityUser);
                serverResponse.Data = _mapper.Map<GetUserDTO>(identityUser);
                return serverResponse;
            }
            else
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid.";
                return serverResponse;
            }        

        }

        
    }
}
