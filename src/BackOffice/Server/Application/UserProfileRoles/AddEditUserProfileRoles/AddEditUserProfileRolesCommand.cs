using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Server.Application.UserProfileRoles.AddEditUserProfileRoles
{
    public class AddEditUserProfileRolesCommand : IRequest<int>
    {
        public AddEditUserProfileRolesCommand(RoleModel roleModel)
        {
            RoleModel = roleModel;
        }

        public RoleModel RoleModel { get; set; }
    }
}
