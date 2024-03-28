

using AutoMapper;
using System.Diagnostics;
using TaskManager.Domain.DTOs;

namespace TaskManager.Infraestructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Activity, ActivityDto>();
            CreateMap<ActivityDto, Activity>();

        }
    }
}
