using System.Globalization;
using System.Windows.Data;
using BirdNet.Data.Entities;

namespace BirdNet.Converters;

public class LineageConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Species? species = value as Species;
        if (species is null) return string.Empty;

        List<string> parts = new List<string>();

        // Extract the species epithet from the scientific name
        string? speciesEpithet = GetSpeciesEpithet(species.ScientificName);

        if (!string.IsNullOrWhiteSpace(speciesEpithet))
            parts.Add(speciesEpithet);

        if (!string.IsNullOrWhiteSpace(species.Genus.Name))
            parts.Add(species.Genus.Name);

        if (!string.IsNullOrWhiteSpace(species.Genus.Family.Name))
            parts.Add(species.Genus.Family.Name);

        if (!string.IsNullOrWhiteSpace(species.Genus.Family.Order.Name))
            parts.Add(species.Genus.Family.Order.Name);

        return string.Join(", ", parts);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    // Private helper method for extracting the species epithet
    private string? GetSpeciesEpithet(string? scientificName)
    {
        if (string.IsNullOrWhiteSpace(scientificName))
            return null;

        string[] parts = scientificName.Split(' ');

        // Return the second part (species epithet), if available
        if (parts.Length >= 2)
        {
            string epithet = parts[1];

            // Capitalize the first letter, make the rest lowercase (optional)
            if (!string.IsNullOrEmpty(epithet))
            {
                return char.ToUpper(epithet[0]) + epithet.Substring(1).ToLower();
            }
        }
        
        return null;
    }
}