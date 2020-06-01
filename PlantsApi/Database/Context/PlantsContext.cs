using Microsoft.EntityFrameworkCore;
using PlantsApi.Models.DbModels;

namespace PlantsApi.Database 
{
    public class PlantsContext : DbContext
    {
        public PlantsContext(DbContextOptions<PlantsContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<PlantState> PlantStates { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>().ToTable("Plant");
            modelBuilder.Entity<Device>().ToTable("Device");
            modelBuilder.Entity<PlantState>().ToTable("PlantState");
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<Device>()
                .HasIndex(d => d.SerialNumber)
                .IsUnique();
        }

	}
}
