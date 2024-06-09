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

        public async Task<List<RoleModel>> GetUserProfileRoles()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RoleModel>>("api/UserProfileRoles/GetUserProfileRoles");
            if (result != null) return result;
            throw new NullReferenceException("Null Reference");
        }

        public async Task<int> DeleteUserProfileRole(int roleId)
        {
            var response = await _httpClient.PostAsJsonAsync("api/UserProfileRoles/DeleteUserProfileRole", roleId);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }

            throw new HttpRequestException($"Failed to add/edit role permissions: {response.ReasonPhrase}");
        }
    }
}
