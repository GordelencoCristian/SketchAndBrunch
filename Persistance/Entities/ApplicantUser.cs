using Microsoft.EntityFrameworkCore;
using Persistance.TrackingEntity;

namespace Persistance.Entities
{
    public class ApplicantUser : SoftDeleteBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
