using BackOffice.Shared.Models;
using MediatR;
using SharedData.Models;

namespace BackOffice.Server.Application.Locations.GetLocations
{
    public class GetLocationsQuery : IRequest<List<LocationModel>>
    {
    }
}
