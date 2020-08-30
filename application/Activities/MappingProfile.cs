using System.Linq;
using Domain;

namespace Application.Activities
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, ActivityDto>();
            CreateMap<UserActivity, AttendeeDto>()
                .ForMember(destination => destination.Username, option => option.MapFrom(source => source.AppUser.UserName))
                .ForMember(destination => destination.DisplayName, option => option.MapFrom(source => source.AppUser.DisplayName))
                .ForMember(destination => destination.Image, option => option.MapFrom(source => source.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}