using System.ComponentModel.DataAnnotations;

namespace CulinaryNotes.WebAPI.Controllers.Entities.User
{
    public class UpdateUserRequest : IValidatableObject
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<int> CulinaryNotesIds { get; set; }
        public List<int> UserRatingsIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
