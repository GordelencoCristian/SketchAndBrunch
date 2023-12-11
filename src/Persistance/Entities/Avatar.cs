using Persistance.TrackingEntity;

namespace Persistance.Entities
{
    public class Avatar : SoftDeleteBaseEntity
    {
        public string Base64ImageData { get; set; }

        public ICollection<UserProfile> UserProfiles { set; get; }
    }
}
