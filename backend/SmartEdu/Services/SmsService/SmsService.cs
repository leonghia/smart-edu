using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartEdu.Controllers;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;

namespace SmartEdu.Services.SmsService
{
    public class SmsService : ISmsService
    {
        private readonly ITwilioRestClient _client;
        private readonly UserManager<User> _userManager;
        private readonly TwilioVerifyOptions _settings;

        public SmsService(ITwilioRestClient client, IOptions<TwilioVerifyOptions> settings, UserManager<User> userManager)
        {
            _client = client;
            _userManager = userManager;
            _settings = settings.Value;
        }

        public async Task<bool> ConfirmVerificationCode(ConfirmPhoneUserDTO confirmPhoneUserDTO, GetUserDTO currentUser)
        {
            var verification = await VerificationCheckResource.CreateAsync(
                to: confirmPhoneUserDTO.PhoneNumber,
                code: confirmPhoneUserDTO.Code,
                pathServiceSid: _settings.VerificationServiceSID,
                client: _client);

            if (verification.Status == "approved")
            {
                var identityUser = await _userManager.FindByIdAsync(currentUser.Id);
                identityUser.PhoneNumberConfirmed = true;
                var result = await _userManager.UpdateAsync(identityUser);
                return result.Succeeded;
            }
            return false;
        }

        public async Task SendSms(SmsMessage model)
        {
            // This will create and send the sms
            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber(model.To),
                from: new PhoneNumber(model.From),
                body: model.Message,
                client: _client);
        }

        public async Task<bool> SendVerificationCode(VerifyPhoneUserDTO verifyPhoneUserDTO, GetUserDTO currentUser)
        {
            var verification = await VerificationResource.CreateAsync(
                to: verifyPhoneUserDTO.PhoneNumber,
                channel: "sms",
                pathServiceSid: _settings.VerificationServiceSID,
                client: _client);

            var identityUser = await _userManager.FindByIdAsync(currentUser.Id);

            await _userManager.SetPhoneNumberAsync(identityUser, verifyPhoneUserDTO.PhoneNumber);

            return verification.Status == "pending";
        }
    }
}
