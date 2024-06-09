using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace BackOffice.Server.Application.UserProfile.DeleteUserProfile
{
    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, int>
    {
        private readonly AppDbContext _appDbContext;

        public DeleteUserProfileCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _appDbContext.UserProfiles
                .FirstOrDefaultAsync(x => x.Id == request.UserProfileId);

            _appDbContext.UserProfiles.Remove(userProfile);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return 0;
        }
    }
}
