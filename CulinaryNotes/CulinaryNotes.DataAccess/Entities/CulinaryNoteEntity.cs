using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("culinary notes")]
public class CulinaryNoteEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Instructions { get; set; }
    public double Rating { get; set; }

    public int UserId { get; set; }
    public UserEntity User { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; }

    public virtual ICollection<UserRatingEntity> UserRatings { get; set; }

    public virtual ICollection<IngredientInCulinaryNoteEntity> IngredientsInCulinaryNote { get; set; }
}