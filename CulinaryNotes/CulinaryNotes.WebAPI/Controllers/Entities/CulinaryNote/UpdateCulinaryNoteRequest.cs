using System.ComponentModel.DataAnnotations;

namespace CulinaryNotes.WebAPI.Controllers.Entities.CulinaryNote
{
    public class UpdateCulinaryNoteRequest : IValidatableObject
    {
        [Required]
        [MinLength(1)]
        public string Heading { get; set; }
        public string? Text { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Required]
        public int UserId { get; set; }

        public List<int> TagIds { get; set; }
        public List<int> FolderIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            return new List<ValidationResult>();
        }
    }
}
