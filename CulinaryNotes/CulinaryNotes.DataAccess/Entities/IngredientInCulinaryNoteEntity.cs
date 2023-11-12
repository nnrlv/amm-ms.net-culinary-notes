using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("ingredients in culinary notes")]
public class IngredientInCulinaryNoteEntity : BaseEntity
{
    public double Amount { get; set; }

    public int CulinaryNoteId { get; set; }
    public CulinaryNoteEntity CulinaryNote { get; set; }

    public int IngredientId { get; set; }
    public IngredientEntity Ingredient { get; set; }

}