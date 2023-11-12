using System.ComponentModel.DataAnnotations;

namespace CulinaryNotes.DataAccess.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; } // ключ в бд

    public Guid ExternalId { get; set; } // unique index - unique optional
    public DateTime ModificationTime { get; set; } // optional
    public DateTime CreationTime { get; set; } //optional 
}