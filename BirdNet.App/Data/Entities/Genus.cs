using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirdNet.Data.Entities;

[Table("Genera")]
public class Genus
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
    
    [Column("familyGuid")]
    public string FamilyGuid { get; set; } = null!;
    
    // Navigation properties
    public Family Family { get; set; } = null!;
    
    public ICollection<Species> Species { get; set; } = [];
}