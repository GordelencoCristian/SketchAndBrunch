using Microsoft.AspNetCore.Identity;

namespace Persistance.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public UserProfile UserProfile { set; get; }
    }
}
