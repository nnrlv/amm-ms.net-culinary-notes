using CulinaryNotes.BusinessLogic.CulinaryNotes;

namespace CulinaryNotes.WebAPI.Controllers.Entities.CulinaryNote
{
    public class CulinaryNotesListResponse
    {
        public List<CulinaryNoteModel> CulinaryNotes { get; set; }
    }
}
