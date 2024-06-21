using FrontOffice.Shared.Models;
using System.Net.Http.Json;

namespace FrontOffice.Client.Services.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> AddRequest(RequestModel requestModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Request/AddRequest", requestModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }

            throw new HttpRequestException($"Failed to add request: {response.ReasonPhrase}");
        }
    }
}
