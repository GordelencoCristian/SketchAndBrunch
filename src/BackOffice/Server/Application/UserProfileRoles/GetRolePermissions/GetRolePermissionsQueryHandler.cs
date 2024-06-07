using AutoMapper;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace BackOffice.Server.Application.UserProfileRoles.GetRolePermissions
{
    public class GetRolePermissionsQueryHandler : IRequestHandler<GetRolePermissionsQuery, List<PermissionsModel>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetRolePermissionsQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<PermissionsModel>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _appDbContext.Permissions.ToListAsync(cancellationToken: cancellationToken);

            try
            {
                return _mapper.Map<List<PermissionsModel>>(permissions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
