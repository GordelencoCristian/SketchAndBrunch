using System.ComponentModel.DataAnnotations.Schema;
using Persistance.TrackingEntity;

namespace Persistance.Entities;

public class SystemRolePermissions : SoftDeleteBaseEntity
{
    public int SystemRoleId { get; set; }
    [ForeignKey(nameof(SystemRoleId)) ]
    public SystemRole SystemRole { get; set; }

    public int PermissionId { get; set; }
    [ForeignKey(nameof(PermissionId))]
    public Permission Permission { get; set; }
}