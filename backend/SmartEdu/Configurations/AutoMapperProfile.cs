using AutoMapper;
using SmartEdu.DTOs.DocumentDTO;
using SmartEdu.DTOs.ExamDTO;
using SmartEdu.DTOs.ExtraClassDTO;
using SmartEdu.DTOs.MainClassDTO;
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
            CreateMap<AddExamDTO, Exam>();
            CreateMap<Exam, GetExamDTO>();
            CreateMap<UpdateExamDTO, Exam>();
            CreateMap<AddExtraClassDTO, ExtraClass>();
            CreateMap<ExtraClass, GetExtraClassDTO>();
            CreateMap<UpdateExtraClassDTO, ExtraClass>();
            CreateMap<UpdateMainClassDTO, MainClass>();
        }
    }
}
