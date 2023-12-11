using MediatR;
using Persistance.Contexts;

namespace BackOffice.Server.Application.UserProfile.AddUserProfile
{
    public class AddUserProfileCommandHandler : IRequestHandler<AddUserProfileCommand, int>
    {
        private readonly AppDbContext _appDbContext;

        public AddUserProfileCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<int> Handle(AddUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = _appDbContext.Users.FirstOrDefault();
            throw new NotImplementedException();
        }
    }
}
