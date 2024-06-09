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
        public DbSet<Permission> Permissions { set; get; }
        public DbSet<SystemRolePermissions> SystemRolePermissions { set; get; }
        public DbSet<Event> Events { set; get; }
        public DbSet<EventLocation> EventLocations { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

    }
}
