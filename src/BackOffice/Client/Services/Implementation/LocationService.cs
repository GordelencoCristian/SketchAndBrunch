using BackOffice.Client.Pages.Location.LocationModal;
using BackOffice.Shared.Models;
using MediatR;
using System.Net.Http.Json;
using SharedData.Models;

namespace BackOffice.Client.Services.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;

        public LocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Unit> AddEditLocation(LocationModel locationModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/location/add-edit", locationModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Unit>();
            }

            throw new HttpRequestException($"Failed to add/edit location: {response.ReasonPhrase}");
        }

        public async Task<Unit> DeleteLocation(int locationId)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/location/delete", locationId);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Unit>();
            }

            throw new HttpRequestException($"Failed to delete location: {response.ReasonPhrase}");
        }

        public async Task<List<LocationModel>> GetLocations()
        {
            var result = await _httpClient.GetFromJsonAsync<List<LocationModel>>("api/location/list");
            if (result != null) return result;
            throw new NullReferenceException("NUll Reference");
        }
    }
}
