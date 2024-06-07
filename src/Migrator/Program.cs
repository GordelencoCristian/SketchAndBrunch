using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistance.Contexts;
using Persistance.Entities;

namespace Migrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("Default");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString);

            using var appDbContext = new AppDbContext(optionsBuilder.Options);

            Console.WriteLine("Starting migration");
            appDbContext.Database.Migrate();

            new DbInitializer(appDbContext).Seed();
            Console.WriteLine("End migration");
        }

        public class DbInitializer
        {
            private readonly AppDbContext _appDbContext;
            public DbInitializer(AppDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }

            public void Seed()
            {
                AddPermissions();
            }

            public void AddPermissions()
            {
                var permissionsList = new List<Permission>
                {
                    new () { Code = "#001", Name = "Users", Description = "Manage Users Tab" },
                    new () { Code = "#002", Name = "SystemRoles", Description = "Manage Roles Tab" },
                    new () { Code = "#003", Name = "Requests", Description = "Manage Requests Tab" }
                };

                foreach (var permission in permissionsList)
                {
                    var contextPermission = _appDbContext.Permissions.FirstOrDefault(x => x.Code == permission.Code);

                    if (contextPermission is not null)
                    {
                        contextPermission.Code = permission.Code;
                        contextPermission.Name = permission.Name;
                        contextPermission.Description = permission.Description;
                    }
                    else
                    {
                        _appDbContext.Permissions.Add(permission);
                    }
                }

                _appDbContext.SaveChanges();
            }

        }

    
    }
}