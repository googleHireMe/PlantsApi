using CardsApi.Models;
using Microsoft.EntityFrameworkCore;
using NotesApi.Models;
using NotesApi.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CardsApi.Repository
{
    public class NotesRepository : INotesRepository
	{
		private readonly NotesContext db;

		public NotesRepository(NotesContext db)
		{
			this.db = db;
		}


        public Note GetNote(int id)
        {
            return db.Notes.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Note> GetNotes()
        {
            return db.Notes
                .Include(n => n.Color)
                .Include(n => n.Priority);
        }
        public Note CreateNote(Note createdNote)
        {
            var note = db.Add(createdNote);
            db.SaveChanges();
            return note.Entity;
        }

        public void UpdateNote(Note updatedNote)
        {
            var note = GetNote(updatedNote.Id);
            note.Name = updatedNote.Name;
            note.Description = updatedNote.Description;
            note.Status = updatedNote.Status;
            note.Date = updatedNote.Date;
            note.PriorityID = updatedNote.PriorityID;
            note.ColorID = updatedNote.ColorID;
            db.SaveChanges();
        }

        public void DeleteNote(int id)
        {
            var note = GetNote(id);
            db.Remove(note);
            db.SaveChanges();
        }

        public Color GetColor(int id) => db.Colors.SingleOrDefault(c => c.Id == id);

        public IEnumerable<Color> GetColors() => db.Colors;

        public Priority GetPriority(int id) => db.Priorities.SingleOrDefault(p => p.Id == id);

        public IEnumerable<Priority> GetPriorities() => db.Priorities;
    }
}
