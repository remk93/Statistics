using Microsoft.EntityFrameworkCore;
using Statistics.DataStorage.Entities;

namespace Statistics.DataStorage.DataContext
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
        }
    }
}
