using BackOffice.Shared.Models;
using MediatR;
using SharedData.Models;

namespace BackOffice.Server.Application.Events.AddEditEvent
{
    public class AddEditEventCommand : IRequest<Unit>
    {
        public AddEditEventCommand(EventModel eventModel)
        {
            EventModel = eventModel;
        }

        public EventModel EventModel { get; set; }
    }
}
