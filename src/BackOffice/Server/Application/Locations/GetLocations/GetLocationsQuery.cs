using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Server.Application.Locations.GetLocations
{
    public class GetLocationsQuery : IRequest<List<LocationModel>>
    {
    }
}
