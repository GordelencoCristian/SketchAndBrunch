using Persistance.TrackingEntity.Interface;

namespace Persistance.TrackingEntity
{
    public abstract class SoftDeleteBaseEntity : BaseEntity, ISoftDeleteEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}
