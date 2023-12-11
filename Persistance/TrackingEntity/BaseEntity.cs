using Persistance.TrackingEntity.Interface;

namespace Persistance.TrackingEntity
{
    public abstract class BaseEntity : ITrackingEntity
    {
        public int Id { get; set; }
        public string CreateById { get; set; }
        public string UpdateById { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
