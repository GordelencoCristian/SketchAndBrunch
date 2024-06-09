using AutoMapper;
using BackOffice.Shared.Models;
using Persistance.Entities;

namespace BackOffice.Server.Application.UserProfile
{
    public class UserProfileMappingProfile : Profile
    {
        public UserProfileMappingProfile()
        {
            CreateMap<UserProfileModel, Persistance.Entities.UserProfile>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(dest => dest.SystemRoleId, opt => opt.MapFrom(src => src.Role.Id))
                ;

            CreateMap<Persistance.Entities.UserProfile, UserProfileModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.SystemRole))
                ;
        }
    }
  
}
