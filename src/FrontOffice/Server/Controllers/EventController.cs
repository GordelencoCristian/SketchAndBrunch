using FrontOffice.Server.Application.Events.GetEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedData.Models;

namespace FrontOffice.Server.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventController : ControllerBase
    {
        private readonly ISender _sender;

        public EventController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("list")]
        public async Task<List<EventModel>> GetEvents()
        {
            return await _sender.Send(new GetEventQuery());
        }
    }
}
