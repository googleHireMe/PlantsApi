using Microsoft.EntityFrameworkCore;
using PlantsApi.Models;

namespace PlantsApi.Database
{
	public class NotesContext : DbContext
	{

		public NotesContext(DbContextOptions<NotesContext> options) : base(options) { }

		public DbSet<Note> Notes { get; set; }
		public DbSet<Priority> Priorities { get; set; }
		public DbSet<Color> Colors { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Note>().ToTable("Note");
			modelBuilder.Entity<Priority>().ToTable("Priority");
			modelBuilder.Entity<Color>().ToTable("Color");
		}

	}
}
