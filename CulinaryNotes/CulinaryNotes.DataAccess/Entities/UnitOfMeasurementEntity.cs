using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryNotes.DataAccess.Entities;

[Table("units of measurement")]
public class UnitOfMeasurementEntity : BaseEntity
{
    public string Name { get; set; }
    public string Abbreviation { get; set; }

    public virtual ICollection<IngredientEntity> Ingredients { get; set; }
}