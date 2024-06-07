using MediatR;
using Persistance.Contexts;

namespace BackOffice.Server.Application.UserProfile.AddUserProfile
{
    public class AddUserProfileCommandHandler : IRequestHandler<AddUserProfileCommand, int>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMediator _mediator;

        public AddUserProfileCommandHandler(AppDbContext appDbContext, IMediator mediator)
        {
            _appDbContext = appDbContext;
            _mediator = mediator;
        }

        public async Task<int> Handle(AddUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = _appDbContext.Users.FirstOrDefault(x => x.UserProfile.Email == "diyna");
        
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
            throw new NotImplementedException();
        }
    }
}
