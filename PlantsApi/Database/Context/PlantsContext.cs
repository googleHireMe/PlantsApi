using Microsoft.EntityFrameworkCore;
using PlantsApi.Models;

namespace PlantsApi.Database 
{
    public class PlantsContext : DbContext
    {
        public PlantsContext(DbContextOptions<PlantsContext> options) : base(options)
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantState> PlantStates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PlantAssignment> PlantAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>().ToTable("Plant");
            modelBuilder.Entity<PlantState>().ToTable("PlantState");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<PlantAssignment>().ToTable("PlantAssignment");

            modelBuilder.Entity<PlantAssignment>()
                .HasKey(pa => new { pa.UserId, pa.PlantId });
        }

	}
}
