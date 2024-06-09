using AutoMapper;
using MediatR;
using Persistance.Contexts;

namespace BackOffice.Server.Application.UserProfile.AddUserProfile
{
    public class AddUserProfileCommandHandler : IRequestHandler<AddUserProfileCommand, int>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddUserProfileCommandHandler(AppDbContext appDbContext, IMediator mediator, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddUserProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedItem = _mapper.Map<Persistance.Entities.UserProfile>(request.UserProfileModel);

                _appDbContext.UserProfiles.Add(mappedItem);
                await _appDbContext.SaveChangesAsync();

                return mappedItem.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
