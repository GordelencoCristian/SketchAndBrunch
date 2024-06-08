using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Server.Application.UserProfileRoles.GetRoles
{
    public class GetRolesQuery : IRequest<List<RoleModel>>
    {
    }
}
