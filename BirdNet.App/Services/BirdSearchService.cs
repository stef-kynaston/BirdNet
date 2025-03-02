using System.Windows.Documents;
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
  }

  public async Task<List<Species>> SearchSpeciesAsync(string? searchQuery)
  {
    if (searchQuery is null)
    {
      return [];
    }

    searchQuery = searchQuery.ToLower();

    List<Species> commonNameResults = await SearchSpeciesByCommonNameAsync(searchQuery);

    List<Species> scientificNameResults = await SearchSpeciesByScientificNameAsync(searchQuery);

    return commonNameResults.Concat(scientificNameResults)
                            .Distinct()
                            .ToList();
  }

  public async Task<List<Species>> SearchSpeciesByCommonNameAsync(string? searchQuery)
  {
    if (searchQuery is null)
    {
      return [];
    }

    searchQuery = searchQuery.ToLower();

    List<Species> results = await _dbContext.Species
        .Where(species => species.CommonNames != null && species.CommonNames.ToLower().Contains(searchQuery))
        .ToListAsync();

    return results;
  }

  public async Task<List<Species>> SearchSpeciesByScientificNameAsync(string? searchQuery)
  {
    if (searchQuery is null)
    {
      return [];
    }

    searchQuery = searchQuery.ToLower();

    List<Species> results = await _dbContext.Species
        .Where(species => species.ScientificName.ToLower().Contains(searchQuery))
        .ToListAsync();

    return results;
  }
}