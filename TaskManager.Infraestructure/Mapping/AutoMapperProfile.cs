

using AutoMapper; 
using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Infraestructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Activity, ActivityDto>();
            CreateMap<ActivityDto,  Activity>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

        }
    }
}
