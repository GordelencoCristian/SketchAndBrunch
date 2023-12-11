using Persistance.TrackingEntity;

namespace Persistance.Entities
{
    public class ScheduledRequest : SoftDeleteBaseEntity
    {
        public DateTime ApplicationDateTime { get; set; }
        public int Duration { get; set; }
        public ApplicantUser ApplicantUser { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
