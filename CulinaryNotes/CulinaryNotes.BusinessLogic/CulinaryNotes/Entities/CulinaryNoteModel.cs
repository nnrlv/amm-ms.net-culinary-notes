using CulinaryNotes.DataAccess.Entities;

namespace CulinaryNotes.BusinessLogic.CulinaryNotes
{
    public class CulinaryNoteModel
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public double Rating { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public List<UserRatingEntity> UserRatings { get; set; }
        public List<IngredientInCulinaryNoteEntity> IngredientsInCulinaryNote { get; set; }
    }
}
