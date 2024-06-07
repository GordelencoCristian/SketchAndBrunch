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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SystemRole>()
                .HasMany(sr => sr.SystemRolePermissions)
                .WithOne(srp => srp.SystemRole)
                .HasForeignKey(srp => srp.SystemRoleId);

            modelBuilder.Entity<Permission>()
                .HasMany(p => p.SystemRolePermissions)
                .WithOne(srp => srp.Permission)
                .HasForeignKey(srp => srp.PermissionId);

            modelBuilder.Entity<SystemRolePermissions>()
                .HasKey(srp => new { srp.SystemRoleId, srp.PermissionId });
        }
    }
}
