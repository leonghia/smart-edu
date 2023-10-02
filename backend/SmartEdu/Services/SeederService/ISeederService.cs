using SmartEdu.DTOs.UserDTO;
using SmartEdu.Models;

namespace SmartEdu.Services.SeederService
{
    public interface ISeederService
    {
        Task<ServerResponse<object>> SeedingData();

        // Them du lieu nguoi dung
        Task SeedingUsers(List<RegisterUserDTO> registerUserDTOs);
        // Them du lieu giao vien
        Task SeedingTeachers(List<RegisterUserDTO> registerUserDTOs);
        // Them du lieu phu huynh
        Task SeedingParents(List<RegisterUserDTO> registerUserDTOs);
        // Them du lieu hoc sinh
        Task SeedingStudents(List<RegisterUserDTO> registerUserDTOs);
        // Them du lieu lop hoc chinh khoa
        Task SeedingMainClasses();
        // Them du lieu lop hoc them
        Task SeedingExtraClasses();
        Task SeedingDocumentsBySubject(DocumentSeederOptions options);
        Task SeedingDocuments();
        Task SeedingMarks();
        Task SeedingTimetables();
        Task SeedingAcademicProgresses();
        Task SeedingAcademicTracker();
    }
}
