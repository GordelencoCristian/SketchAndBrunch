using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistance.Contexts;

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

            using var sc = new AppDbContext(optionsBuilder.Options);

            Console.WriteLine("Starting migration");
            sc.Database.Migrate();
            //new DbInitializer(sc).Seed();
            Console.WriteLine("End migration");
        }

        public void Seed()
        {

        }
    }
}