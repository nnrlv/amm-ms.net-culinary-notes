using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("users")]
public class UserEntity :  IdentityRole<int>, IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public virtual ICollection<CulinaryNoteEntity> CulinaryNotes { get; set; }
    public virtual ICollection<UserRatingEntity> UserRatings { get; set; }

}
public class UserRoleEntity : IdentityRole<int>
{
}