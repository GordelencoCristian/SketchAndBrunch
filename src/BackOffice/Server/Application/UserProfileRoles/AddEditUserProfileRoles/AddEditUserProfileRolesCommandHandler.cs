using AutoMapper;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.Entities;

namespace BackOffice.Server.Application.UserProfileRoles.AddEditUserProfileRoles
{
    public class AddEditUserProfileRolesCommandHandler : IRequestHandler<AddEditUserProfileRolesCommand, int>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AddEditUserProfileRolesCommandHandler(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(AddEditUserProfileRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.RoleModel.Id is not null)
                {
                    var systemRole = _appDbContext.SystemRoles.First(x => x.Id == request.RoleModel.Id);

                    _mapper.Map(request.RoleModel, systemRole);
                    await _appDbContext.SaveChangesAsync(cancellationToken);
                    return systemRole.Id;
                }

                var mappedItem = _mapper.Map<SystemRole>(request.RoleModel);
                _appDbContext.SystemRoles.Add(mappedItem);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                foreach (var permission in request.RoleModel.Permissions)
                {
                    var systemRolePermission = new SystemRolePermissions
                        { PermissionId = permission.Id, SystemRoleId = mappedItem.Id };

                    _appDbContext.SystemRolePermissions.Add(systemRolePermission);
                }

                await _appDbContext.SaveChangesAsync(cancellationToken);
        
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
