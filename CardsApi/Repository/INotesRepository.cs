using CardsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Models
{
    public interface INotesRepository
    {

        Note GetNote(int id);
        IEnumerable<Note> GetNotes();
        Note CreateNote(Note createdNote);
        void UpdateNote(Note updatedNote);
        void DeleteNote(int id);

        Color GetColor(int id);
        IEnumerable<Color> GetColors();

        Priority GetPriority(int id);
        IEnumerable<Priority> GetPriorities();
    }
}
