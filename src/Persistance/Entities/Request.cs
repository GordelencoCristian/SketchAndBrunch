using System.ComponentModel.DataAnnotations.Schema;
using Persistance.Enums;
using Persistance.TrackingEntity;

namespace Persistance.Entities
{
    public class Request : SoftDeleteBaseEntity
    {
        public RequestStatusEnum? Status { get; set; }
        public DateTime ApplicationDateTime { get; set; }
        public ApplicantUser ApplicantUser { get; set; }

        public int? UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int? EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event? Event { get; set; }
    }
}
