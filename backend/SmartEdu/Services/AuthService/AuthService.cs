using AutoMapper;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartEdu.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IOptions<GoogleAuthOptions> _googleAuthOptions;
        private readonly IOptions<FacebookAuthOptions> _facebookAuthOptions;
        private readonly HttpClient _httpClient;
        private User _user;

        public User User
        {
            get => _user;
            set => _user = value;
        }

        public AuthService(UserManager<User> userManager, IConfiguration configuration, IMapper mapper, IOptions<GoogleAuthOptions> googleAuthOptions, IOptions<FacebookAuthOptions> facebookAuthOptions, HttpClient httpClient)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _googleAuthOptions = googleAuthOptions;
            _facebookAuthOptions = facebookAuthOptions;
            _httpClient = httpClient;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateToken(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddSeconds(Convert.ToDouble(jwtSettings.GetSection("Lifetime").Value));
            var token = new JwtSecurityToken(
                    issuer: jwtSettings.GetSection("Issuer").Value,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: signingCredentials
                );
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim("username", _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            return claims;
        }

        private static SigningCredentials GetSigningCredentials()
        {
            var key = Environment.GetEnvironmentVariable("KEY");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginUserDTO loginUserDTO)
        {
            _user = await _userManager.FindByNameAsync(loginUserDTO.Username);
            return _user is not null && await _userManager.CheckPasswordAsync(_user, loginUserDTO.Password);
        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(GoogleAuthUserDTO googleAuthUserDTO)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _googleAuthOptions.Value.ClientId }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(googleAuthUserDTO.IdToken, settings);

                return payload;

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong in the {nameof(VerifyGoogleToken)} method.");
                return null;
            }
        }   

        public async Task<FacebookUserInfo> VerifyFacebookToken(FacebookAuthUserDTO facebookAuthUserDTO)
        {           
            HttpResponseMessage httpResponseMessageForToken = await _httpClient.GetAsync($"https://graph.facebook.com/debug_token?input_token={facebookAuthUserDTO.Credential}&access_token={_facebookAuthOptions.Value.AppId}|{_facebookAuthOptions.Value.AppSecret}");

            var stringThing = await httpResponseMessageForToken.Content.ReadAsStringAsync();
            var userOBJK = JsonConvert.DeserializeObject<FacebookUser>(stringThing);

            HttpResponseMessage httpResponseMessageForUser = await _httpClient.GetAsync($"https://graph.facebook.com/me?fields=first_name,last_name,email,id&access_token={facebookAuthUserDTO.Credential}");
            var userContent = await httpResponseMessageForUser.Content.ReadAsStringAsync();
            var userContentObj = JsonConvert.DeserializeObject<FacebookUserInfo>(userContent);

            if (userOBJK.Data.IsValid)
            {
                return userContentObj;
            }
            return null;
        }
    }
}
