using AutoMapper;
using BackOffice.Shared.Models;
using Persistance.Entities;
using SharedData.Models;

namespace BackOffice.Server.Application.Locations
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile() 
        {
            CreateMap<EventLocation, LocationModel>();

            CreateMap<LocationModel, EventLocation>()
                .ForMember(x => x.Id, opts => opts.Ignore());
        }
    }
}
