using SharedData.Models;
using System.Net.Http.Json;

namespace FrontOffice.Client.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    
        public async Task<List<EventModel>> GetEvents()
        {
            var result = await _httpClient.GetFromJsonAsync<List<EventModel>>("api/event/list");
            if (result != null) return result;
            throw new NullReferenceException("NUll Reference");
        }
    }
}
