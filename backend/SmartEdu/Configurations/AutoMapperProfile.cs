using AutoMapper;
using SmartEdu.DTOs.DocumentDTO;
using SmartEdu.DTOs.ParentDTO;
using SmartEdu.DTOs.StudentDTO;
using SmartEdu.DTOs.SubjectDTO;
using SmartEdu.DTOs.TeacherDTO;
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

        }
    }
}
