using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Repository
{
	//public class FakeRepository : INotesRepository
	//{
	//	private static List<Note> cards = new List<Note> {
	//		new Note {
	//			Id = 1,
	//			Name = "name",
	//			Description = "description",
	//			Status = false,
	//			Priority = 1,
	//			Color = "color",
	//			Date = DateTime.Now
	//		},
	//		new Note {
	//			Id = 2,
	//			Name = "name2",
	//			Description = "description2",
	//			Status = false,
	//			Priority = 2,
	//			Color = "color2",
	//			Date = DateTime.Now
	//		}
	//	};

	//	public Note GetNote(int id)
	//	{
	//		return cards.Single(c => c.Id == id);
	//	}

	//	public IEnumerable<Note> GetNotes()
	//	{
	//		return cards;
	//	}

	//	public Note CreateNote(Note createdNote)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	public void UpdateNote(Note updatedNote)
	//	{
	//		var card = cards.Single(c => c.Id == updatedNote.Id);
	//		card.Name = updatedNote.Name;
	//		card.Description = updatedNote.Description;
	//		card.Status = updatedNote.Status;
	//		card.Priority = updatedNote.Priority;
	//		card.Color = updatedNote.Color;
	//		card.Date = updatedNote.Date;
	//	}

	//	public void DeleteNote(Note deletedNote)
	//	{
	//		throw new NotImplementedException();
	//	}
	//}

}
