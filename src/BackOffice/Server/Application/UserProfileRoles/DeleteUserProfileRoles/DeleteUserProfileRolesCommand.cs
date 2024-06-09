using MediatR;

namespace BackOffice.Server.Application.UserProfileRoles.DeleteUserProfileRoles
{
    public class DeleteUserProfileRolesCommand : IRequest<int>
    {
        public DeleteUserProfileRolesCommand(int roleId)
        {
            RoleId = roleId;
        }

        public int RoleId { get; set; }
    }
}
