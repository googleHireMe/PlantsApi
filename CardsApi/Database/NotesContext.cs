using NotesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardsApi.Models;

namespace NotesApi.Repository
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
