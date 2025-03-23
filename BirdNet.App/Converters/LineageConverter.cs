using System.Globalization;
using System.Windows.Data;
using BirdNet.Data.Entities;

namespace BirdNet.Converters;

public class LineageConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Species species) 
        {
            return string.Empty;
        }

        List<string> parts = [];

        // Extract the species epithet from the scientific name

        if (!string.IsNullOrWhiteSpace(species.SpeciesEpithet))
            parts.Add(species.SpeciesEpithet);

        if (!string.IsNullOrWhiteSpace(species.Genus.Name))
            parts.Add(species.Genus.Name);

        if (!string.IsNullOrWhiteSpace(species.Genus.Family.Name))
            parts.Add(species.Genus.Family.Name);

        if (!string.IsNullOrWhiteSpace(species.Genus.Family.Order.Name))
            parts.Add(species.Genus.Family.Order.Name);

        return string.Join(", ", parts);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}