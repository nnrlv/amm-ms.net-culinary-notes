using System.ComponentModel.DataAnnotations;

namespace CulinaryNotes.WebAPI.Controllers.Entities.CulinaryNote
{
    public class CreateCulinaryNoteRequest : IValidatableObject
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        public string Instructions { get; set; }
        public double Rating { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<int> UserRatingsIds { get; set; }
        public List<int> IngredientsInCulinaryNoteIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            return new List<ValidationResult>();
        }
    }
}
