namespace CulinaryNotes.BusinessLogic.CulinaryNotes
{
    public class UpdateCulinaryNoteModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public double Rating { get; set; }

        public List<int> UserRatingsIds { get; set; }
    }
}
