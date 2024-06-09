using BackOffice.Shared.Models;
using System.Net.Http.Json;

namespace BackOffice.Client.Services.Implementation
{
    public class UserProfileService : IUserProfileService
    {
        private readonly HttpClient _httpClient;

        public UserProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> AddEditUserProfile(UserProfileModel userProfileModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/UserProfile/AddEditUserProfile", userProfileModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }

            throw new HttpRequestException($"Failed to add/edit user profile: {response.ReasonPhrase}");
        }

        public async Task<List<UserProfileModel>> GetUserProfiles()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserProfileModel>>("api/UserProfile/GetUserProfiles");
            if (result != null) return result;
            throw new NullReferenceException("Null Reference");
        }
    }
}
