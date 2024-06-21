using AutoMapper;
using FrontOffice.Shared.Models;
using Persistance.Entities;
using SharedData.Models;

namespace FrontOffice.Server.Application.Requests
{
    public class RequestMappingProfile : Profile
    {
        public RequestMappingProfile()
        {
            CreateMap<Request, RequestModel>()
                .ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.Event))
                .ForMember(dest => dest.ApplicantUser, opt => opt.MapFrom(src => src.ApplicantUser));

            CreateMap<RequestModel, Request>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(dest => dest.UserProfileId, opt => opt.Ignore())
                .ForMember(dest => dest.UserProfile, opt => opt.Ignore())

                .ForMember(dest => dest.ApplicationDateTime, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Event.Id))
                .ForMember(dest => dest.Event, opt => opt.Ignore());
            ;

            CreateMap<ApplicantUserModel, ApplicantUser>();
        }
    }
}
