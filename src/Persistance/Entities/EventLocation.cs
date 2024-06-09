using Persistance.TrackingEntity;

namespace Persistance.Entities
{
    public class EventLocation : SoftDeleteBaseEntity
    {
        public string? Name { get; set; }
        public string? Adress { get; set; }

    }
}
