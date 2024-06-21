using BackOffice.Shared.Models;
using MediatR;
using SharedData.Models;

namespace BackOffice.Server.Application.Events.GetEvents
{
    public class GetEventQuery : IRequest<List<EventModel>>
    {
    }
}
