using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace BackOffice.Server.Application.UserProfileRoles.DeleteUserProfileRoles
{
    public class DeleteUserProfileRolesCommandHandler : IRequestHandler<DeleteUserProfileRolesCommand, int>
    {
        private readonly AppDbContext _appDbContext;

        public DeleteUserProfileRolesCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(DeleteUserProfileRolesCommand request, CancellationToken cancellationToken)
        {
            var role = await _appDbContext.SystemRoles.Include(x => x.SystemRolePermissions)
                .FirstOrDefaultAsync(x => x.Id == request.RoleId);

            _appDbContext.SystemRoles.Remove(role);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return 0;
        }
    }
}
