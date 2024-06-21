using AutoMapper;
using BackOffice.Shared.Models;
using Persistance.Entities;
using SharedData.Models;

namespace BackOffice.Server.Application.Requests
{
    public class RequestsMappingProfile : Profile
    {
        public RequestsMappingProfile()
        {
            CreateMap<Request, RequestModel>()
                .ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.Event))
                .ForMember(dest => dest.UserProfile, opt => opt.MapFrom(src => src.UserProfile))
                .ForMember(dest => dest.ApplicantUser, opt => opt.MapFrom(src => src.ApplicantUser));

            CreateMap<ApplicantUserModel, ApplicantUser>();
            CreateMap<ApplicantUser, ApplicantUserModel>();

            CreateMap<RequestModel, Request>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(dest => dest.UserProfileId, opt => opt.MapFrom(src => src.UserProfile.Id))
                .ForMember(dest => dest.UserProfile, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicationDateTime, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Event.Id))
                .ForMember(dest => dest.Event, opt => opt.Ignore());
            ;
        }
    }
 
}
