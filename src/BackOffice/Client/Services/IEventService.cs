using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Client.Services
{
    public interface IEventService
    {
        Task<List<EventModel>> GetEvents();
        Task<Unit> AddEditEvent(EventModel eventModel);
        Task<Unit> DeleteEvent(int eventId);
    }
}
