//using CulinaryNotes.BusinessLogic.CulinaryNotes.Entities;

namespace CulinaryNotes.BusinessLogic.CulinaryNotes
{
    public interface ICulinaryNotesProvider
    {
        IEnumerable<CulinaryNoteModel> GetCulinaryNotes(CulinaryNoteModelFilter filter = null);
        CulinaryNoteModel GetCulinaryNoteInfo(Guid id);
    }
}
