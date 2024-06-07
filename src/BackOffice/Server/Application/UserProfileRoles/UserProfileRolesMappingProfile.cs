using AutoMapper;
using BackOffice.Shared.Models;
using Persistance.Entities;

namespace BackOffice.Server.Application.UserProfileRoles
{
    public class UserProfileRolesMappingProfile : Profile
    {
        public UserProfileRolesMappingProfile()
        {
            CreateMap<RoleModel, SystemRole>()
                .ForMember(x => x.Id, opts => opts.Ignore());
                //.ForMember(x => x.SystemRolePermissions, opts => opts.MapFrom(x => x.Permissions));

            CreateMap<Permission, PermissionsModel>();
            CreateMap<PermissionsModel, Permission>();
        }
    }
}
