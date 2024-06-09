using Persistance.TrackingEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistance.Entities
{
    public class Event : SoftDeleteBaseEntity
    {
        public string Name { get; set; }
        public DateTime EventTime { get; set; }
        public string Description { get; set; }
        public int NumberOfparticipants { get; set; }

        public int? EventLocationId { get; set; }

        [ForeignKey(nameof(EventLocationId))]
        public EventLocation EventLocation { get; set; }
    }
}
