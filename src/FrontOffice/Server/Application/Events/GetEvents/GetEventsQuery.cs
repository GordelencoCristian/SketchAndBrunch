using MediatR;
using SharedData.Models;

namespace FrontOffice.Server.Application.Events.GetEvents
{
    public class GetEventQuery : IRequest<List<EventModel>>
    {
    }
}
