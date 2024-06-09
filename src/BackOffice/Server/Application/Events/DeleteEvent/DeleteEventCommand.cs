using MediatR;

namespace BackOffice.Server.Application.Events.DeleteEvent
{
    public class DeleteEventCommand : IRequest<Unit>
    {
        public DeleteEventCommand(int eventId)
        {
            EventId = eventId;
        }

        public int EventId { get; set; }
    }
}
