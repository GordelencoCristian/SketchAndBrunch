using BackOffice.Server.Application.Locations.AddEditLocation;
using BackOffice.Server.Application.Locations.DeleteLocation;
using BackOffice.Server.Application.Locations.GetLocations;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedData.Models;

namespace BackOffice.Server.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class LocationController : ControllerBase
    {
        private readonly ISender _sender;

        public LocationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("list")]
        public async Task<List<LocationModel>> GetLocations()
        {
            return await _sender.Send(new GetLocationsQuery());
        }

        [HttpPost("add-edit")]
        public async Task<Unit> AddEditLocation([FromBody] LocationModel locationModel)
        {
            return await _sender.Send(new AddEditLocationCommand(locationModel));
        }

        [HttpPost("delete")]
        public async Task<Unit> DeleteLocation([FromBody] int locationId)
        {
            return await _sender.Send(new DeleteLocationCommand(locationId));
        }
    }
}
