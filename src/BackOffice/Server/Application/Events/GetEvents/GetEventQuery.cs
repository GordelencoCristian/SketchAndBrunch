using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Server.Application.Events.GetEvents
{
    public class GetEventQuery : IRequest<List<EventModel>>
    {
    }
}
