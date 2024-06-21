using BackOffice.Shared.Models;
using System.Net.Http.Json;
using MediatR;

namespace BackOffice.Client.Services.Implementation
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> AddEditRequest(RequestModel requestModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Request/AddEditRequest", requestModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }

            throw new HttpRequestException($"Failed to add/edit request: {response.ReasonPhrase}");
        }

        public async Task<int> ChangeStatus(ChangeStatusModel changeStatusModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Request/ChangeStatus", changeStatusModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }

            throw new HttpRequestException($"Failed to change status to request: {response.ReasonPhrase}");
        }

        public async Task<List<RequestModel>> GetRequests()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RequestModel>>("api/Request/GetRequests");
            if (result != null) return result;
            throw new NullReferenceException("Null Reference");

        }

        public async Task<Unit> DeleteRequest(int? requestId)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Request/DeleteRequest", requestId);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Unit>();
            }

            throw new HttpRequestException($"Failed to add/edit role permissions: {response.ReasonPhrase}");
        }
    }
}
