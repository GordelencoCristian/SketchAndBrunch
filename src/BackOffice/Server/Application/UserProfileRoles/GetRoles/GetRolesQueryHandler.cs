using AutoMapper;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace BackOffice.Server.Application.UserProfileRoles.GetRoles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleModel>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private int _index = 1;

        public GetRolesQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<RoleModel>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _appDbContext.SystemRoles
                .Include(x => x.SystemRolePermissions)
                .ThenInclude(x => x.Permission)
                .ToListAsync(cancellationToken: cancellationToken);

            var mappedList = _mapper.Map<List<RoleModel>>(roles);

            foreach (var role in mappedList)
            {
                role.Number = _index;
                _index++;
            }

            return mappedList;
        }
    }
}
