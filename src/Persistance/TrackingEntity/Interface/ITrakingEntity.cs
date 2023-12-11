namespace Persistance.TrackingEntity.Interface
{
    public interface ITrackingEntity
    {
        int Id { get; set; }
        string CreateById { get; set; }
        string UpdateById { get; set; }
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
