using BackOffice.Shared.Models;

namespace BackOffice.Client.Services
{
    public interface IUserProfilePermissionsRoleService
    {
        Task<List<PermissionsModel>> GetRolePermissions();
        Task<int> AddEditRolePermissions(RoleModel roleModel);
        Task<List<RoleModel>> GetUserProfileRoles();
    }
}
