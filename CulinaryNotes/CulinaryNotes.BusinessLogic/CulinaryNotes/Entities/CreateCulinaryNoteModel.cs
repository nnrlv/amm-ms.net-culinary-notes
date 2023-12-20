namespace CulinaryNotes.BusinessLogic.CulinaryNotes
{
    public class CreateCulinaryNoteModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public double Rating { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public List<int> UserRatingsIds { get; set; }
        public List<int> IngredientsInCulinaryNoteIds { get; set; }
    }
}