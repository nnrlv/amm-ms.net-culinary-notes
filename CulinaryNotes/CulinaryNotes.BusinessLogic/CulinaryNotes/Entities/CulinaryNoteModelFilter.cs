using CulinaryNotes.DataAccess.Entities;

namespace CulinaryNotes.BusinessLogic.CulinaryNotes
{
    public class CulinaryNoteModelFilter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public double Rating { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
