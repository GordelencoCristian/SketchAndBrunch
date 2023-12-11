using Microsoft.EntityFrameworkCore;
using Persistance.Entities;
using SpatialFocus.EntityFrameworkCore.Extensions;

namespace Persistance.Contexts
{
    public class AppDbContext : ModuleDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserProfile> UserProfiles { set; get; }
        public DbSet<ApplicantUser> ApplicantUsers { set; get; }
        public DbSet<Avatar> Avatars { set; get; }
        public DbSet<Request> Requests { set; get; }
        public DbSet<ScheduledRequest> ScheduledRequests { set; get; }
        public DbSet<SystemRole> SystemRoles { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
