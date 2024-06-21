using BackOffice.Shared.Models;
using MediatR;
using System.Net.Http.Json;
using SharedData.Models;

namespace BackOffice.Client.Services.Implementation
{
    public class EventService : IEventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Unit> AddEditEvent(EventModel eventModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/event/add-edit", eventModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Unit>();
            }

            throw new HttpRequestException($"Failed to add/edit event: {response.ReasonPhrase}");
        }

        public async Task<Unit> DeleteEvent(int eventId)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/event/delete", eventId);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Unit>();
            }

            throw new HttpRequestException($"Failed to delete event: {response.ReasonPhrase}");
        }

        public async Task<List<EventModel>> GetEvents()
        {
            var result = await _httpClient.GetFromJsonAsync<List<EventModel>>("api/event/list");
            if (result != null) return result;
            throw new NullReferenceException("NUll Reference");
        }
    }
}
