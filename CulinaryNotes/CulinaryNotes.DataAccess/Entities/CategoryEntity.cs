using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("categories")]
public class CategoryEntity : BaseEntity
{
    public string Name { get; set; }

    public int? CategoryId { get; set; }
    public CategoryEntity? ParentCategory { get; set; }

    public virtual ICollection<CategoryEntity> Categories { get; set; }
    public virtual ICollection<CulinaryNoteEntity> CulinaryNotes { get; set; }
}