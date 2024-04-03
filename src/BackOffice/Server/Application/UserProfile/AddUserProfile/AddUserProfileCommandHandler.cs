using BackOffice.Server.Application.UserProfile.GetNumberOfCigarets;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

            var numberOfCigarets = await _mediator.Send(new GetNumberOfCigaretsQyery
            {
                Id = 2,
                IsReady = true
            });

            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
