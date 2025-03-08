using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirdNet.Data.Entities;

[Table("Families")]
public class Family
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

    [Column("orderGuid")]
    public string OrderGuid { get; set; } = null!;

    // Navigation properties
    public Order Order { get; set; } = null!;

    public ICollection<Genus> Genera { get; set; } = [];
}