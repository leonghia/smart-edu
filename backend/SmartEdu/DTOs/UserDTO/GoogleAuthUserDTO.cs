namespace SmartEdu.DTOs.UserDTO
{
    public class GoogleAuthUserDTO
    {
        public string? Provider { get; set; }
        public string? IdToken { get; set; }
        public List<string>? Roles { get; set; }
    }
}
