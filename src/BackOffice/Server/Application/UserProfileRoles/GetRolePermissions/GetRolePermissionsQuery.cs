using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Server.Application.UserProfileRoles.GetRolePermissions
{
    public class GetRolePermissionsQuery : IRequest<List<PermissionsModel>>
    {
    }
}
