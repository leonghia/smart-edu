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
                serverResponse.Message = "Invalid username or password. Please try again.";
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

        public async Task<ServerResponse<object>> SeedingUsers()
        {
            var serverResponse = new ServerResponse<object>();

            var roles = new List<string> { "User" };

            var registerUserDTOs =new List<RegisterUserDTO>
            {
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Giang",
                    UserName = "giang",
                    Email = "giang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3 
                },
                new RegisterUserDTO
                {
                    FullName = "Pham Thi Nguyet Anh",
                    UserName = "anhpham",
                    Email = "anh.pham@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Dam Thuy Duong",
                    UserName = "duong",
                    Email = "duong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Huong",
                    UserName = "huong",
                    Email = "nguyenhuongg1104@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = new List<string> { "Admin" },
                    Type = 0
                },
                new RegisterUserDTO
                {
                    FullName = "Trinh Van Phuc",
                    UserName = "phuc",
                    Email = "phuctv1112004@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = new List<string> { "Admin" },
                    Type = 0
                },
                new RegisterUserDTO // 1
                {
                    FullName = "Leu Ngoc An",
                    UserName = "an0149107377",
                    Email = "an0149107377@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 2
                {
                    FullName = "Nguyen Ngoc Tram Anh",
                    UserName = "anh0116701758",
                    Email = "anh0116701758@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 3
                {
                    FullName = "Pham Viet Anh",
                    UserName = "anh0133530105",
                    Email = "anh0133530105@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 4
                {
                    FullName = "Bui Thi Quynh Anh",
                    UserName = "anh3616460199",
                    Email = "anh3616460199@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 5
                {
                    FullName = "Vu Duc Anh",
                    UserName = "anh1734705112",
                    Email = "anh1734705112@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 6
                {
                    FullName = "Nguyen Phung Linh Chi",
                    UserName = "chi0149107460",
                    Email = "chi0149107460@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 7
                {
                    FullName = "Duong My Dung",
                    UserName = "dung0116989583",
                    Email = "dung0116989583@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 8
                {
                    FullName = "Nguyen Manh Duy",
                    UserName = "duy0150499677",
                    Email = "duy0150499677@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 9
                {
                    FullName = "Pham Phuong Duy",
                    UserName = "duy0116479556",
                    Email = "duy0116479556@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 10
                {
                    FullName = "Nguyen Thuy Duong",
                    UserName = "duong0133058338",
                    Email = "duong0133058338@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 11
                {
                    FullName = "Luu Minh Hang",
                    UserName = "hang0116971907",
                    Email = "hang0116971907@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 12
                {
                    FullName = "Nguyen Huu Minh Hoang",
                    UserName = "hoang0116952467",
                    Email = "hoang0116952467@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 13
                {
                    FullName = "Nguyen Huy Hoang",
                    UserName = "hoang0149107469",
                    Email = "hoang0149107469@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 14
                {
                    FullName = "Nguyen Duc Huy",
                    UserName = "huy0116575041",
                    Email = "huy0116575041@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 15
                {
                    FullName = "Vu Duc Huy",
                    UserName = "huy0116701214",
                    Email = "huy0116701214@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 16
                {
                    FullName = "Nguyen Trung Kien",
                    UserName = "kien3316697828",
                    Email = "kien3316697828@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 17
                {
                    FullName = "Le Duy Khiem",
                    UserName = "khiem0137566271",
                    Email = "khiem0137566271@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO // 18
                {
                    FullName = "Nguyen Minh Khue",
                    UserName = "khue0150707773",
                    Email = "khue0150707773@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //19
                {
                    FullName = "Bui Hai Lam",
                    UserName = "lam0134001874",
                    Email = "lam0134001874@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //20
                {
                    FullName = "Nguyen Ha Gia Linh",
                    UserName = "linh0116973081",
                    Email = "linh0116973081@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //21
                {
                    FullName = "Nguyen Phuc Loc",
                    UserName = "loc0116574901",
                    Email = "loc0116574901@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //22
                {
                    FullName = "Hoang Huong Ly",
                    UserName = "ly0150498659",
                    Email = "ly0150498659@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //23
                {
                    FullName = "Trinh Xuan Minh",
                    UserName = "minh0155210714",
                    Email = "minh0155210714@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //24
                {
                    FullName = "Nguyen Vu Tien Nam",
                    UserName = "nam0116695176",
                    Email = "nam0116695176@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //25
                {
                    FullName = "Pham Thi Hang Nga",
                    UserName = "nga0134705129",
                    Email = "nga0134705129@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //26
                {
                    FullName = "Hoang Kim Ngan",
                    UserName = "ngan0133530178",
                    Email = "ngan0133530178@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //27
                {
                    FullName = "Hoang Yen Nhi",
                    UserName = "nhi0134705133",
                    Email = "nhi0134705133@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //28
                {
                    FullName = "Mai Ngo Thien Phu",
                    UserName = "phu0134705135",
                    Email = "phu0134705135@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //29
                {
                    FullName = "Le Tien Tam",
                    UserName = "tam0100712147",
                    Email = "tam0100712147@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //30
                {
                    FullName = "Tran Xuan Toan",
                    UserName = "toan0133487571",
                    Email = "toan0133487571@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },new RegisterUserDTO //31
                {
                    FullName = "Le Minh Tuan",
                    UserName = "tuan0133530254",
                    Email = "tuan0133530254@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //32
                {
                    FullName = "Duong Tat Thanh",
                    UserName = "thanh0134100841",
                    Email = "thanh0134100841@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //33
                {
                    FullName = "Le Cao Thang",
                    UserName = "thang0155203520",
                    Email = "thang0155203520@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //34
                {
                    FullName = "Dang Phuong Thuy",
                    UserName = "thuy0144525596",
                    Email = "thuy0144525596@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //35
                {
                    FullName = "Nguyen Thu Trang",
                    UserName = "trang0134100853",
                    Email = "trang0134100853@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },
                new RegisterUserDTO //36
                {
                    FullName = "Nguyen Thuy Trang",
                    UserName = "trang0134100856",
                    Email = "trang0134100856@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1
                },

                // Parents
                new RegisterUserDTO // 1
                {
                    FullName = "Leu Minh Duc",
                    UserName = "duc0149107377",
                    Email = "duc0149107377@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 2
                {
                    FullName = "Nguyen Ngoc Bao",
                    UserName = "bao0116701758",
                    Email = "bao0116701758@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 3
                {
                    FullName = "Pham Viet Hung",
                    UserName = "hung0133530105",
                    Email = "hung0133530105@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 4
                {
                    FullName = "Bui Thi Quynh Mai",
                    UserName = "mai3616460199",
                    Email = "mai3616460199@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 5
                {
                    FullName = "Vu Tuan Minh ",
                    UserName = "minh1734705112",
                    Email = "minh1734705112@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 6
                {
                    FullName = "Nguyen The Toan",
                    UserName = "toan0149107460",
                    Email = "toan0149107460@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 7
                {
                    FullName = "Duong My Hanh",
                    UserName = "hanh0116989583",
                    Email = "hanh0116989583@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 8
                {
                    FullName = "Nguyen Manh Dung",
                    UserName = "dung0150499677",
                    Email = "dung0150499677@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 9
                {
                    FullName = "Pham Phuong Thuy",
                    UserName = "thuy0116479556",
                    Email = "thuy0116479556@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 10
                {
                    FullName = "Nguyen Thuy Dung",
                    UserName = "dung0133058338",
                    Email = "dung0133058338@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 11
                {
                    FullName = "Luu Thi Hong",
                    UserName = "hong0116971907",
                    Email = "hong0116971907@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 12
                {
                    FullName = "Nguyen Huu Minh",
                    UserName = "minh0116952467",
                    Email = "minh0116952467@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 13
                {
                    FullName = "Nguyen Huy Long",
                    UserName = "long0149107469",
                    Email = "long0149107469@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 14
                {
                    FullName = "Nguyen Duc Toan",
                    UserName = "toan0116575041",
                    Email = "toan0116575041@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 15
                {
                    FullName = "Vu Duc Dam",
                    UserName = "dam0116701214",
                    Email = "dam0116701214@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 16
                {
                    FullName = "Nguyen Trung Thanh",
                    UserName = "thanh3316697828",
                    Email = "thanh3316697828@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 17
                {
                    FullName = "Le Duy Khanh",
                    UserName = "khanh0137566271",
                    Email = "khanh0137566271@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 18
                {
                    FullName = "Nguyen Minh Ngoc",
                    UserName = "ngoc0150707773",
                    Email = "ngoc0150707773@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //19
                {
                    FullName = "Bui Hai Luong",
                    UserName = "luong0134001874",
                    Email = "luong0134001874@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //20
                {
                    FullName = "Nguyen Gia Bao",
                    UserName = "bao0116973081",
                    Email = "bao0116973081@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //21
                {
                    FullName = "Nguyen Phuc Duc",
                    UserName = "duc0116574901",
                    Email = "duc0116574901@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //22
                {
                    FullName = "Hoang Huong Nhung",
                    UserName = "nhung0150498659",
                    Email = "nhung0150498659@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //23
                {
                    FullName = "Trinh Xuan Thanh",
                    UserName = "thanh0155210714",
                    Email = "thanh0155210714@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //24
                {
                    FullName = "Nguyen Vu Tien",
                    UserName = "tien0116695176",
                    Email = "tien0116695176@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //25
                {
                    FullName = "Pham Thi Hang",
                    UserName = "hang0134705129",
                    Email = "hang0134705129@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //26
                {
                    FullName = "Hoang Kim Trang",
                    UserName = "trang0133530178",
                    Email = "trang0133530178@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //27
                {
                    FullName = "Hoang Thi Men",
                    UserName = "men0134705133",
                    Email = "men0134705133@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //28
                {
                    FullName = "Mai Thien Hoang",
                    UserName = "hoang0134705135",
                    Email = "hoang0134705135@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //29
                {
                    FullName = "Le Tien Tuan",
                    UserName = "tuan0100712147",
                    Email = "tuan0100712147@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //30
                {
                    FullName = "Tran Xuan Linh",
                    UserName = "linh0133487571",
                    Email = "linh0133487571@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },new RegisterUserDTO //31
                {
                    FullName = "Le Minh Quan",
                    UserName = "quan0133530254",
                    Email = "quan0133530254@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //32
                {
                    FullName = "Duong Tat Phuc",
                    UserName = "phuc0134100841",
                    Email = "phuc0134100841@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //33
                {
                    FullName = "Le Cao Duc",
                    UserName = "duc0155203520",
                    Email = "duc0155203520@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //34
                {
                    FullName = "Dang Phuong Linh",
                    UserName = "linh0144525596",
                    Email = "linh0144525596@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //35
                {
                    FullName = "Nguyen Le Thu",
                    UserName = "thu0134100853",
                    Email = "thu0134100853@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //36
                {
                    FullName = "Nguyen  Thi Thuy",
                    UserName = "thuy0134100856",
                    Email = "thuy0134100856@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
            };

            foreach (var registerUserDTO in registerUserDTOs)
            {
                var user = _mapper.Map<User>(registerUserDTO);
                // tao tai khoan cho mooi giao vien va them vao trong DB

                await _userManager.CreateAsync(user,
                    registerUserDTO.Password);
                await _userManager.AddToRolesAsync(user,
                    roles);
            }

            serverResponse.Message = "Seeding users successfully";
            return serverResponse;
        }

        public async Task<ServerResponse<object>> SeedingTeachers()
        {
            var serverResponse = new ServerResponse<object>();

            var users = await _userManager.Users.ToListAsync();

            Teacher teacher = null;

            //for (var i = 0; i < users.Count; i++)
            //{
            //    var user = users.ElementAt(i);
            //    if (user.Type == 3)
            //    {
            //        teacher = new Teacher
            //        {
            //            Id = 1,
            //            UserId = user.Id,
            //            MainClassId = i + 1,
            //            SubjectId = 1
            //        };
            //    }
            //}

            var mainClassId = 1;
            var id = 1;
            var teachers = new List<Teacher>();
            foreach (var user in users)
            {
                if (user.Type == 3)
                {
                    var t = new Teacher
                    {
                        Id = id,
                        UserId = user.Id,
                        MainClassId = mainClassId,
                        SubjectId = 1
                    };
                    teachers.Add(t);
                    id++;
                    mainClassId++;
                }
                
            }
            await _unitOfWork.TeacherRepository.AddRange(teachers);
            
            await _unitOfWork.Save();

            serverResponse.Message = "Seeding Teachers successfully";

            return serverResponse;
        }

        public async Task<ServerResponse<object>> SeedingStudents()
        {
            var serverResponse = new ServerResponse<object>();

            var users = await _userManager.Users.ToListAsync();
            var students = new List<Student>();
            var id = 1;
            var count = 0;
            var mainClassId = 1;

            foreach (var user in users)
            {
                if (user.Type == 1)
                {

                    if (count == 36)
                    {
                        mainClassId++;
                        count = 0;
                    }
                    var student = new Student
                    {
                        Id = id,
                        UserId = user.Id,
                        ParentId = id,
                        MainClassId = mainClassId,
                    };
                    students.Add(student);
                    count++;
                    id++;
                }
            }

            await _unitOfWork.StudentRepository.AddRange(students);
            await _unitOfWork.Save();

            serverResponse.Message = "Add students successfully";
            return serverResponse;
        }

        public async Task<ServerResponse<object>> SeedingParents()
        {
            var serverResponse = new ServerResponse<object>();

            var users = await _userManager.Users.ToListAsync();

            var parents = new List<Parent>();

            var id = 1;
            
            foreach(var user in users)
            {
                if (user.Type == 2)
                {
                    var parent = new Parent
                    {
                        Id = id,
                        UserId = user.Id,
                    };
                    parents.Add(parent);
                    id++;
                }
                
            }
            
            await _unitOfWork.ParentRepository.AddRange(parents);

            await _unitOfWork.Save();
            serverResponse.Message = "Seeding parents successfully.";
            return serverResponse;
        }

        public async Task<ServerResponse<object>> SeedingData()
        {
            await SeedingUsers();
            await SeedingTeachers();
            await SeedingParents();
            await SeedingStudents();

            var serverResponse = new ServerResponse<object>();
            serverResponse.Message = "Seeding data successfully";
            return serverResponse;
        }
    }
}
