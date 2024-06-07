using Persistance.TrackingEntity;

namespace Persistance.Entities
{
    public class Permission : SoftDeleteBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }     
        public string Code { get; set; }

        public ICollection<SystemRolePermissions> SystemRolePermissions { get; set; }
    }
}
