using Google.Apis.Auth;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using SmartEdu.Models;

namespace SmartEdu.Services.AuthService
{
    public interface IAuthService
    {
        Task<bool> ValidateUser(LoginUserDTO loginUserDTO);
        Task<string> CreateToken();
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(GoogleAuthUserDTO googleAuthUserDTO);
        Task<FacebookUserInfo> VerifyFacebookToken(FacebookAuthUserDTO facebookAuthUserDTO);
        User User { get; set; }
    }
}
