using SmartEdu.DTOs.UserDTO;
using SmartEdu.Models;

namespace SmartEdu.Services.SmsService
{
    public interface ISmsService
    {
        Task SendSms(SmsMessage model);
        Task<bool> ConfirmVerificationCode(ConfirmPhoneUserDTO confirmPhoneUserDTO, GetUserDTO currentUser);
        Task<bool> SendVerificationCode(VerifyPhoneUserDTO verifyPhoneUserDTO, GetUserDTO currentUser);
    }
}
