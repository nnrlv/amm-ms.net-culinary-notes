using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("user ratings")]
public class UserRatingEntity : BaseEntity
{
    public int Grade { get; set; }
    public string Comment { get; set; }

    public int UserId { get; set; }
    public UserEntity User { get; set; }

    public int CulinaryNoteId { get; set; }
    public CulinaryNoteEntity CulinaryNote { get; set; }

}