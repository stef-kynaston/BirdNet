using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirdNet.Data.Entities;

[Table("Orders")]
public class Order
{
    [Key]
    [Column("guid")]
    public string Guid { get; set; } = null!;

    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("commonName")]
    public string? CommonName { get; set; } = null!;
    
    // Navigation properties
    public ICollection<Family> Families { get; set; } = [];
}