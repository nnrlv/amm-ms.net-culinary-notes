using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("users")]
public class UserEntity : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public virtual ICollection<CulinaryNoteEntity> CulinaryNotes { get; set; }
    public virtual ICollection<UserRatingEntity> UserRatings { get; set; }
}