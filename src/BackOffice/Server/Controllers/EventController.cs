using BackOffice.Server.Application.Events.AddEditEvent;
using BackOffice.Server.Application.Events.DeleteEvent;
using BackOffice.Server.Application.Events.GetEvents;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Server.Controllers
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

        [HttpPost("add-edit")]
        public async Task<Unit> AddEditEvent([FromBody] EventModel eventModel)
        {
            return await _sender.Send(new AddEditEventCommand(eventModel));
        }

        [HttpPost("delete")]
        public async Task<Unit> DeleteEvent([FromBody] int eventId)
        {
            return await _sender.Send(new DeleteEventCommand(eventId));
        }
    }
}
