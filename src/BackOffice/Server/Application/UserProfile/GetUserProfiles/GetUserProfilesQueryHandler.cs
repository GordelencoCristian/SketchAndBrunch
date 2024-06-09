using AutoMapper;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace BackOffice.Server.Application.UserProfile.GetUserProfiles
{
    public class GetUserProfilesQueryHandler : IRequestHandler<GetUserProfilesQuery, List<UserProfileModel>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private int _index = 1;

        public GetUserProfilesQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<UserProfileModel>> Handle(GetUserProfilesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userProfiles = await _appDbContext.UserProfiles
                    .Include(x => x.SystemRole)
                    .ThenInclude(x => x.SystemRolePermissions)
                    .ThenInclude(x => x.Permission)
                    .ToListAsync(cancellationToken: cancellationToken);

                var mappedList = _mapper.Map<List<UserProfileModel>>(userProfiles);

                foreach (var role in mappedList)
                {
                    role.Number = _index;
                    _index++;
                }

                return mappedList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
