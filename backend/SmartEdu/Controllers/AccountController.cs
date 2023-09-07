using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Models;
using SmartEdu.Services.AccountService;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using SmartEdu.Services.AuthService;
using SmartEdu.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        

        public AccountController(UserManager<User> userManager, IMapper mapper, IAccountService accountService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _accountService = accountService;    
        }       

        /// <summary>
        /// Retrieve the currently logged-in user.
        /// </summary>
        /// <returns></returns>       
        [Authorize(Roles = "Admin,User")]
        [HttpGet("user")]
        public async Task<IActionResult> GetCurrent()
        {
            var serverResponse = new ServerResponse<GetUserDTO>();
            var currentUser = await _accountService.GetCurrentUser();
            var identityUser = await _userManager.FindByIdAsync(currentUser.Id);
            currentUser.Roles = await _userManager.GetRolesAsync(identityUser);
            serverResponse.Data = currentUser;
            return Ok(serverResponse);
        }

        /// <summary>
        /// Retrieve all the users (Admin required).
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams)
        {
            var serverResponse = new ServerResponse<List<GetUserDTO>>();
            var usersDTO = (await _accountService.GetAllUsers(requestParams, null)).Select(u => _mapper.Map<GetUserDTO>(u)).ToList();
            serverResponse.Data = usersDTO;
            return Ok(serverResponse);
        }

        /// <summary>
        /// Register a new user. Roles should be "Admin" or "User". Only Admin can register another Admin. After register, a confirmation link would be sent to the registered email.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            Log.Information("Registration attempt for {Email}", registerUserDTO.Email);
            var serverResponse = await _accountService.CreateUserAndAddRoles(registerUserDTO, ModelState);
            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            return Accepted(serverResponse);
        }

        /// <summary>
        /// Send a confirmation link to the email of the current-logged in user.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("verify-email")]
        public async Task<IActionResult> VerifyEmail()
        {
            var currentUser = await _accountService.GetCurrentUser();
            var identityUser = await _userManager.FindByIdAsync(currentUser.Id);
            await _accountService.VerifyEmail(identityUser);
            return NoContent();
        }

        /// <summary>
        /// Confirm the email registered. In production, the confirmation link in the email should redirect the user to the client UI (e.g. Angular) then the client request this endpoint and display the result accordingly.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string email)
        {
            Log.Information("Confirm email attempt for {Email}", email);
            var serverResponse = await _accountService.ConfirmEmail(token, email, ModelState);
            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            return Ok(serverResponse);
        }

        /// <summary>
        /// Request a verification code to be send to the specified phone number.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [Route("verify-phone")]
        public async Task<IActionResult> VerifyPhone([FromBody] VerifyPhoneUserDTO verifyPhoneUserDTO)
        {
            Log.Information("Verify phone attempt for {Phone}", verifyPhoneUserDTO.PhoneNumber);
            var serverResponse = await _accountService.VerifyPhone(verifyPhoneUserDTO, ModelState);
            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            return NoContent();
        }

        /// <summary>
        /// Confirm the phone number with the specified verification code.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [Route("confirm-phone")]
        public async Task<IActionResult> ConfirmPhone([FromBody] ConfirmPhoneUserDTO confirmPhoneUserDTO)
        {
            Log.Information("Confirm phone attemp for phone {Phone}", confirmPhoneUserDTO.PhoneNumber);
            var serverResponse = await _accountService.ConfirmPhone(confirmPhoneUserDTO, ModelState);
            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            return Accepted(serverResponse);
        }

        /// <summary>
        /// Login to the website. The response would include a token so that the client could request for secured resources.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            Log.Information("Login attempt for {Username}", loginUserDTO.Username);
            var serverResponse = await _accountService.Login(loginUserDTO, ModelState);
            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            Log.Information("Login successfully for username = {Username}", loginUserDTO.Username);
            return Accepted(serverResponse);
        }

        /// <summary>
        /// Request a reset-password link sent to the specified email.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordUserDTO forgotPasswordUserDTO)
        {           
            Log.Information("Forgot password attempt for {Email}", forgotPasswordUserDTO.Email);
            var serverResponse = await _accountService.ForgotPassword(forgotPasswordUserDTO, ModelState);
            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            return NoContent();
        }

        /// <summary>
        /// Register a new password.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordUserDTO resetPasswordUserDTO)
        {           
            Log.Information("Reset password attempt for {Email}", resetPasswordUserDTO.Email);
            var serverResponse = await _accountService.ResetPassword(resetPasswordUserDTO, ModelState);
            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            return Accepted(serverResponse);
        }

        /// <summary>
        /// Delete a user (Admin required). 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserDTO deleteUserDTO)
        {
            Log.Information("Delete attempt for {Username}", deleteUserDTO.Username);
            var serverResponse = await _accountService.DeleteUser(deleteUserDTO, ModelState);
            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            return Ok(serverResponse);
        }

        /// <summary>
        /// Update a user. Since this is a PUT method, client would need to fill all the required properties in the request body.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDTO updateUserDTO)
        {
            Log.Information("Update attempt for {Username}", updateUserDTO.UserName);
            var serverResponse = await _accountService.UpdateUser(updateUserDTO, ModelState);
            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            return Ok(serverResponse);
        }

        /// <summary>
        /// Login to the website with a Google account.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleAuthUserDTO googleAuthUserDTO)
        {
            var serverResponse = await _accountService.GoogleLogin(googleAuthUserDTO);

            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            
            return Accepted(serverResponse);
        }

        /// <summary>
        /// Login to the website with a Facebook account.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("facebook-login")]
        public async Task<IActionResult> FacebookLogin([FromBody] FacebookAuthUserDTO facebookAuthUserDTO)
        {
            var serverResponse = await _accountService.FacebookLogin(facebookAuthUserDTO);

            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }

            return Accepted(serverResponse);
        }

        /// <summary>
        /// Update profile image for the current logged-in user.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User")]
        [HttpPut]
        [Route("profile-image")]
        public async Task<IActionResult> UpdateProfileImage([FromForm] MultipleFilesModel model)
        {
            var serverResponse = await _accountService.UpdateProfileImage(model, ModelState);
            if (!serverResponse.Succeeded)
            {
                return BadRequest(serverResponse);
            }
            return Accepted(serverResponse);
        }       
    }
}
