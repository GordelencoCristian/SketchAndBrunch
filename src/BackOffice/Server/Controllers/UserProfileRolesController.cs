using BackOffice.Server.Application.UserProfileRoles.AddEditUserProfileRoles;
using BackOffice.Server.Application.UserProfileRoles.GetRolePermissions;
using BackOffice.Server.Application.UserProfileRoles.GetRoles;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserProfileRolesController : ControllerBase
    {
        private readonly ISender _sender;

        public UserProfileRolesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<List<PermissionsModel>> RolePermissions()
        {
            return await _sender.Send(new GetRolePermissionsQuery());
        }

        [HttpPost]
        public async Task<int> AddEditRolePermissions([FromBody] RoleModel roleModel)
        {
            return await _sender.Send(new AddEditUserProfileRolesCommand(roleModel));
        }

        [HttpGet]
        public async Task<List<RoleModel>> GetUserProfileRoles()
        {
            return await _sender.Send(new GetRolesQuery());
        }
    }
}
