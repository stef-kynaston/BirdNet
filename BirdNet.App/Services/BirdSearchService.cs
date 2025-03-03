using BirdNet.Data.Entities;
using BirdNet.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BirdNet.Services;

public class BirdSearchService
{
    private readonly AppDbContext _dbContext;

    public BirdSearchService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _ = _dbContext.Species.FirstOrDefault();
    }

    public async Task<List<Species>> SearchSpeciesAsync(string? searchQuery)
    {
        if (searchQuery is null)
        {
            return [];
        }

        searchQuery = searchQuery.ToLower();

        // Search by common name and scientific name
        List<Species> commonNameResults = await SearchSpeciesByCommonNameAsync(searchQuery);
        List<Species> scientificNameResults = await SearchSpeciesByScientificNameAsync(searchQuery);

        return commonNameResults.Concat(scientificNameResults)
            .Distinct()
            .ToList();
    }

    private async Task<List<Species>> SearchSpeciesByCommonNameAsync(string? searchQuery)
    {
        if (string.IsNullOrWhiteSpace(searchQuery))
        {
            return [];
        }

        searchQuery = searchQuery.ToLower();

        return await _dbContext.Species
            .Where(species => species.CommonNames != null && species.CommonNames.ToLower().Contains(searchQuery))
            .ToListAsync();
    }

    private async Task<List<Species>> SearchSpeciesByScientificNameAsync(string? searchQuery)
    {
        if (string.IsNullOrWhiteSpace(searchQuery))
        {
            return [];
        }

        searchQuery = searchQuery.ToLower();

        return await _dbContext.Species
            .Where(species => species.ScientificName.ToLower().Contains(searchQuery))
            .ToListAsync();
    }
}