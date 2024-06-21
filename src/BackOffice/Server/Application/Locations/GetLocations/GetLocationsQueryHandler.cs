using AutoMapper;
using BackOffice.Server.Application.UserProfileRoles.GetRolePermissions;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using SharedData.Models;

namespace BackOffice.Server.Application.Locations.GetLocations
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, List<LocationModel>>
    {

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetLocationsQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async  Task<List<LocationModel>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _appDbContext.EventLocations.OrderByDescending(el => el.CreateDate).ToListAsync(cancellationToken: cancellationToken);

            try
            {
                return _mapper.Map<List<LocationModel>>(permissions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
