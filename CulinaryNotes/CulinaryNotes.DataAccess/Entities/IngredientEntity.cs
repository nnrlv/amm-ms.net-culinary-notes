using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("ingredients")]
public class IngredientEntity : BaseEntity
{
    public string Name { get; set; }

    public int UnitOfMeasurementId { get; set; }
    public UnitOfMeasurementEntity UnitOfMeasurement { get; set; }

    public virtual ICollection<IngredientInCulinaryNoteEntity>
        IngredientsInCulinaryNote { get; set; }
}