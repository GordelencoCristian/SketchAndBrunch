using Microsoft.AspNetCore.Identity;

namespace Persistance.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<UserProfile> UserProfiles { set; get; }
    }
}
