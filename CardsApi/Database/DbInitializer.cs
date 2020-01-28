using CardsApi.Models;
using NotesApi.Models;
using NotesApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsApi.Database
{
	public static class DbInitializer
	{
		public static void Initialize(NotesContext context)
		{
			//context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
			if (context.Notes.Any()) { return; }

			var colors = GetColors();
			colors.ForEach(c => context.Colors.Add(c));

			var priorities = GetPriorities();
			priorities.ForEach(p => context.Priorities.Add(p));

			var notes = GetNotes();
			notes.ForEach(n => context.Notes.Add(n));

			context.SaveChanges();
		}

		private static List<Note> GetNotes()
		{
			return new List<Note>
			{
				new Note
				{
					Name = "Hi, my name is Slim Shady",
					Description = "Subscribe to Eminem",
					Status = false,
					Date = DateTime.Now,
					ColorID = 1,
					PriorityID = 1
				},
				new Note
				{
					Name = "Boring second ToDo",
					Description = "Improve this proj somehow....",
					Status = false,
					Date = DateTime.Now,
					ColorID = 2,
					PriorityID = 3
				},
		   };
		}

		private static List<Color> GetColors()
		{
			return new List<Color>
			{
				new Color
				{
					Id = 1,
					Description = "Red",
					Value = ""
				},
				new Color
				{
					Id = 2,
					Description = "Green",
					Value = ""
				},
				new Color
				{
					Id = 3,
					Description = "Blue",
					Value = ""
				}
			};
		}

		private static List<Priority> GetPriorities()
		{
			return new List<Priority>
			{
				new Priority
				{
					Id = 1,
					Value = 1,
					Description = "Highest"
				},
				new Priority
				{
					Id = 2,
					Value = 2,
					Description = "High"
				},
				new Priority
				{
					Id = 3,
					Value = 3,
					Description = "Medium"
				},
				new Priority
				{
					Id = 4,
					Value = 4,
					Description = "Low"
				},
				new Priority
				{
					Id = 5,
					Value = 5,
					Description = "Lowest"
				}
			};

		}

	}

}
