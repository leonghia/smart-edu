using AutoMapper;
using SmartEdu.DTOs.AcademicProgressDTO;
using SmartEdu.DTOs.AcademicTrackerDTO;
using SmartEdu.DTOs.DocumentDTO;
using SmartEdu.DTOs.EcBookmarkDTO;
using SmartEdu.DTOs.ExtraClassDTO;
using SmartEdu.DTOs.ExtraClassStudentDTO;
using SmartEdu.DTOs.MainClassDTO;
using SmartEdu.DTOs.MarkDTO;
using SmartEdu.DTOs.ParentDTO;
using SmartEdu.DTOs.StudentDTO;
using SmartEdu.DTOs.SubjectDTO;
using SmartEdu.DTOs.TeacherDTO;
using SmartEdu.DTOs.TimetableDTO;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;

namespace SmartEdu.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<User, GetUserDTO>();
            CreateMap<RegisterUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();     
            
            CreateMap<AddDocumentDTO, Document>();
            CreateMap<Document, GetDocumentDTO>();
            CreateMap<UpdateDocumentDTO, Document>();
            CreateMap<AddExtraClassDTO, ExtraClass>();
            CreateMap<ExtraClass, GetExtraClassDTO>();
            CreateMap<UpdateExtraClassDTO, ExtraClass>();
            CreateMap<AddMainClassDTO, MainClass>();
            CreateMap<MainClass, GetMainClassDTO>();
            CreateMap<UpdateMainClassDTO, MainClass>();
            CreateMap<AddTeacherDTO, Teacher>();
            CreateMap<Teacher, GetTeacherDTO>();
            CreateMap<UpdateTeacherDTO, Teacher>();
            CreateMap<AddParentDTO, Parent>();
            CreateMap<Parent, GetParentDTO>();
            CreateMap<UpdateParentDTO, Parent>();
            CreateMap<AddStudentDTO, Student>();
            CreateMap<Student, GetStudentDTO>();
            CreateMap<UpdateStudentDTO, Student>();
            CreateMap<AddSubjectDTO, Subject>();
            CreateMap<Subject, GetSubjectDTO>();
            CreateMap<UpdateSubjectDTO, Subject>();
            CreateMap<AddExtraClassStudentDTO, ExtraClassStudent>();
            CreateMap<EcBookmark, GetEcBookmarkDTO>();
            CreateMap<AddExtraClassEcBookmarkDTO, ExtraClassEcBookmark>();
            CreateMap<Mark, GetMarkDTO>();
            CreateMap<AddMarkDTO, Mark>();
            CreateMap<UpdateMarkDTO, Mark>();
            CreateMap<Timetable, GetTimetableDTO>();
            CreateMap<AcademicProgress, GetAcademicProgressDTO>();
            CreateMap<AcademicTracker, GetAcademicTrackerDTO>();
        }
    }
}
