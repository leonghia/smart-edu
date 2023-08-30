using Microsoft.AspNetCore.Mvc.ModelBinding;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.JsonPatch;

namespace SmartEdu.Services.AccountService
{
    public interface IAccountService
    {        
        Task<GetUserDTO> GetCurrentUser();        
        Task<bool> IsAdministrator(GetUserDTO currentUser);
        Task<bool> CanUserUpdateOrGetHisEntity<TEntity>(Expression<Func<TEntity, bool>> filter, GetUserDTO currentUser) where TEntity : class;
        Task<IEnumerable<User>> GetAllUsers(RequestParams requestParams, List<string>? includes = null);
        Task<ServerResponse<object>> CreateUserAndAddRoles(RegisterUserDTO registerUserDTO, ModelStateDictionary modelState);

        Task VerifyEmail(User user);
        Task<ServerResponse<object>> ConfirmEmail(string token, string email, ModelStateDictionary modelState);
        Task<ServerResponse<object>> VerifyPhone(VerifyPhoneUserDTO verifyPhoneUserDTO, ModelStateDictionary modelState);
        Task<ServerResponse<object>> ConfirmPhone(ConfirmPhoneUserDTO confirmPhoneUserDTO, ModelStateDictionary modelState);
        Task<ServerResponse<object>> Login(LoginUserDTO loginUserDTO, ModelStateDictionary modelState);
        Task<ServerResponse<object>> ForgotPassword(ForgotPasswordUserDTO forgotPasswordUserDTO, ModelStateDictionary modelState);
        Task<ServerResponse<object>> ResetPassword(ResetPasswordUserDTO resetPasswordUserDTO, ModelStateDictionary modelState);
        Task<ServerResponse<object>> DeleteUser(DeleteUserDTO deleteUserDTO, ModelStateDictionary modelState);
        Task<ServerResponse<object>> UpdateUser(UpdateUserDTO updateUserDTO, ModelStateDictionary modelState);
        
        Task<ServerResponse<AuthResponseUserDTO>> GoogleLogin(GoogleAuthUserDTO googleAuthUserDTO);
        Task<ServerResponse<AuthResponseUserDTO>> FacebookLogin(FacebookAuthUserDTO facebookAuthUserDTO);
        Task<ServerResponse<GetUserDTO>> UpdateProfileImage(MultipleFilesModel model, ModelStateDictionary modelState);

        
    }
}
