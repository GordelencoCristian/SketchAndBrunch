namespace Persistance.TrackingEntity.Interface
{
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { set; get; }
        DateTime? DeleteTime { get; set; }
    }
}
