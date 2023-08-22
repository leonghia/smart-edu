using AutoMapper;
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
        }
    }
}
