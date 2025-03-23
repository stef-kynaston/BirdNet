using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BirdNet.Extensions;

namespace BirdNet.Data.Entities;

public class Species
{
    #region Mapped Properties

    [Key]
    [Column("guid")]
    public string Guid { get; set; } = null!;

    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("name")]
    public string ScientificName { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("commonName")]
    public string? CommonNames { get; set; } = null!;

    [Column("commonNameSingle")]
    public string CommonNameSingle { get; set; } = null!;

    [Column("occurrenceCount")]
    public int OccurrenceCount { get; set; } = 0;

    [Column("isNative")]
    public bool IsNative { get; set; } = false;

    [Column("habitat")]
    public string? Habitats { get; set; } = null!;

    [Column("genusGuid")]
    public string GenusGuid { get; set; } = null!;

    #endregion

    #region Computed Properties

    [NotMapped]
    public string SpeciesEpithet => ScientificName.Split(" ")[1].ToTitleCase();

    #endregion

    #region Navigation properties

    public Genus Genus { get; set; } = null!;

    #endregion


    #region Methods

    public override string ToString()
    {
        return CommonNameSingle;
    }

    #endregion
}