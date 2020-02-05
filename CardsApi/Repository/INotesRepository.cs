using System.Collections.Generic;
using PlantsApi.Models;

namespace PlantsApi.Repository
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
