using AutoMapper;
using BackOffice.Shared.Models;
using Persistance.Entities;

namespace BackOffice.Server.Application.Events
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<Event, EventModel>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.EventLocation));

            CreateMap<EventModel, Event>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(dest => dest.EventLocationId, opt => opt.MapFrom(src => src.Location.Id));
                ;

            CreateMap<EventLocation, LocationModel>();

            CreateMap<LocationModel, EventLocation>();
        }
    }
}
