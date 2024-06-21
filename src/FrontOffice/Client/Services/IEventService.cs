using SharedData.Models;

namespace FrontOffice.Client.Services
{
    public interface IEventService
    {
        Task<List<EventModel>> GetEvents();
    }
}
