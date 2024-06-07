using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistance.TrackingEntity.Interface;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Persistance.Entities;
using SpatialFocus.EntityFrameworkCore.Extensions;

namespace Persistance.Contexts
{
    public abstract class ModuleDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private static readonly MethodInfo? ConfigureGlobalFiltersMethodInfo = typeof(ModuleDbContext).GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);
        protected string _currentUserId = "0";

        protected ModuleDbContext()
        {
        }

        protected ModuleDbContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModuleDbContext).Assembly);
            //modelBuilder.ConfigureEnumLookup(EnumLookupOptions.Default.SetNamingScheme(n => n).UseNumberAsIdentifier().SetDeleteBehavior(DeleteBehavior.Restrict));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                ConfigureGlobalFiltersMethodInfo?.MakeGenericMethod(entityType.ClrType).Invoke(this, new object[] { modelBuilder, entityType });
            }
        }

        protected void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType) where TEntity : class
        {
            if (entityType.BaseType == null && typeof(ISoftDeleteEntity).IsAssignableFrom(typeof(TEntity)))
            {
                var filterExpression = CreateFilterExpression<TEntity>();

                if (entityType.IsKeyless)
                {
                    modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
                }
                else
                {
                    modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
                }
            }
        }

        protected virtual Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>() where TEntity : class
        {
            Expression<Func<TEntity, bool>> expression = null;

            if (typeof(ISoftDeleteEntity).IsAssignableFrom(typeof(TEntity)))
            {
                Expression<Func<TEntity, bool>> softDeleteFilter = e => false || !((ISoftDeleteEntity)e).IsDeleted;
                expression = softDeleteFilter;
            }

            return expression;
        }

        public override int SaveChanges()
        {
            ApplyTrackingConcept();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyTrackingConcept();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyTrackingConcept()
        {
            ChangeTracker.DetectChanges();

            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);
            var markedAsCreated = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            var markedAsEdited = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var item in markedAsDeleted)
            {
                AssignOnDeleting(item);
            }

            foreach (var item in markedAsCreated)
            {
                AssignOnCreation(item);
                AssignOnEditing(item);
            }

            foreach (var item in markedAsEdited)
            {
                AssignOnEditing(item);
            }
        }

        private void AssignOnCreation(EntityEntry item)
        {
            if (item.Entity is ITrackingEntity trackingEntity)
            {
                trackingEntity.CreateById = _currentUserId;
                trackingEntity.CreateDate = DateTime.Now;
            }
        }

        private void AssignOnEditing(EntityEntry item)
        {
            if (item.Entity is ITrackingEntity trackingEntity)
            {
                trackingEntity.UpdateById = _currentUserId;
                trackingEntity.UpdateDate = DateTime.Now;
            }
        }

        private void AssignOnDeleting(EntityEntry item)
        {
            if (item.Entity is ISoftDeleteEntity entity)
            {
                AssignOnEditing(item);

                if (entity.IsDeleted == false)
                {
                    // Set the entity to unchanged (if we mark the whole entity as Modified, every field gets sent to Db as an update)
                    item.State = EntityState.Unchanged;
                    // Only update the IsDeleted flag - only this will get sent to the Db
                    entity.IsDeleted = true;
                    entity.DeleteTime = DateTime.Now;
                }
            }
        }
    }
}
