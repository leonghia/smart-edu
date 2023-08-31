using SmartEdu.DTOs.UserDTO;
using SmartEdu.Models;

namespace SmartEdu.Services.SeederService
{
    public interface ISeederService
    {
        Task<ServerResponse<object>> SeedingData();

        // Them du lieu nguoi dung
        Task<ServerResponse<object>> SeedingUsers(List<RegisterUserDTO> registerUserDTOs);
        // Them du lieu giao vien
        Task<ServerResponse<object>> SeedingTeachers(List<RegisterUserDTO> registerUserDTOs);
        // Them du lieu phu huynh
        Task<ServerResponse<object>> SeedingParents(List<RegisterUserDTO> registerUserDTOs);
        // Them du lieu hoc sinh
        Task<ServerResponse<object>> SeedingStudents(List<RegisterUserDTO> registerUserDTOs);
    }
}
