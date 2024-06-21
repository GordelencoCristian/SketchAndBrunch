using BackOffice.Shared.Models;
using MediatR;
using SharedData.Models;

namespace BackOffice.Client.Services
{
    public interface IEventService
    {
        Task<List<EventModel>> GetEvents();
        Task<Unit> AddEditEvent(EventModel eventModel);
        Task<Unit> DeleteEvent(int eventId);
    }
}
