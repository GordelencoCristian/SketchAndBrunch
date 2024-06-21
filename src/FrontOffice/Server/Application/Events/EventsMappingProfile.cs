using AutoMapper;
using Persistance.Entities;
using SharedData.Models;

namespace FrontOffice.Server.Application.Events
{
    public class EventsMappingProfile : Profile
    {
        public EventsMappingProfile()
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
