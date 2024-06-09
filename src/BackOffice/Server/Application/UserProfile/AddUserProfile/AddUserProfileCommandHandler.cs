using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.Entities;

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
                if (request.UserProfileModel.Id is not null)
                {
                    var userProfile = await _appDbContext.UserProfiles
                        .Include(x => x.SystemRole)
                        .FirstOrDefaultAsync(x => x.Id == request.UserProfileModel.Id, cancellationToken: cancellationToken);


                    _mapper.Map(request.UserProfileModel, userProfile);

                    await _appDbContext.SaveChangesAsync(cancellationToken);
                    return userProfile.Id;
                }

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
