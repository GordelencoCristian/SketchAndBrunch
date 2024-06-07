using BackOffice.Shared.Models;
using SharedData.Models;
using System.Net.Http.Json;

namespace BackOffice.Client.Services.Implementation
{
    public class UserProfilePermissionsRoleService : IUserProfilePermissionsRoleService
    {
        private readonly HttpClient _httpClient;

        public UserProfilePermissionsRoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PermissionsModel>> GetRolePermissions()
        {
            var result = await _httpClient.GetFromJsonAsync<List<PermissionsModel>>("api/UserProfileRoles/RolePermissions");
            if (result != null) return result;
            throw new NullReferenceException("NUll Reference");
        }

        public async Task<int> AddEditRolePermissions(RoleModel roleModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/UserProfileRoles/AddEditRolePermissions", roleModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }

            throw new HttpRequestException($"Failed to add/edit role permissions: {response.ReasonPhrase}");
        }
    }
}
