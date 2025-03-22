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

    public async Task<List<Species>> SearchSpeciesByCommonNameAsync(string? searchQuery)
    {
        if (string.IsNullOrWhiteSpace(searchQuery) || searchQuery.Length < 3) return [];

        searchQuery = searchQuery.ToLower();

        return await _dbContext.Species
            .Where(species => species.CommonNames != null && species.CommonNames.ToLower().Contains(searchQuery))
            .Include(species => species.Genus)
            .ThenInclude(genus => genus.Family)
            .ThenInclude(family => family.Order)
            .ToListAsync();
    }

    public async Task<List<Species>> SearchSpeciesByScientificNameAsync(string? searchQuery)
    {
        if (string.IsNullOrWhiteSpace(searchQuery) || searchQuery.Length < 3) return [];

        searchQuery = searchQuery.ToLower();

        return await _dbContext.Species
            .Where(species => species.ScientificName.ToLower().Contains(searchQuery))
            .Include(species => species.Genus)
            .ThenInclude(genus => genus.Family)
            .ThenInclude(family => family.Order)
            .ToListAsync();
    }
}