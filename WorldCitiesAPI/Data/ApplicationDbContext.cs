using Microsoft.EntityFrameworkCore;
using WorldCitiesAPI.Data.Models; //import City.cs and Country.cs

namespace WorldCitiesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<City> Cities => Set<City>();
        public DbSet<Country> Countries => Set<Country>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            System.Console.WriteLine("Model is Built");
            base.OnModelCreating(modelBuilder);
        }
    }
}
  