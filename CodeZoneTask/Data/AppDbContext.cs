using CodeZoneTask.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CodeZoneTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> optionsBuilder) : base(optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Item> Items { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
