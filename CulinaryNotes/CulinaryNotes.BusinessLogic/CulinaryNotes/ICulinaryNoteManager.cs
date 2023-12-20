//using CulinaryNotes.BusinessLogic.CulinaryNotes.Entities;

namespace CulinaryNotes.BusinessLogic.CulinaryNotes
{
    public interface ICulinaryNoteManager
    {
        CulinaryNoteModel CreateCulinaryNote(CreateCulinaryNoteModel model);
        void DeleteCulinaryNote(Guid id);
        CulinaryNoteModel UpdateCulinaryNote(Guid id, CulinaryNoteModel model);
    }
}
