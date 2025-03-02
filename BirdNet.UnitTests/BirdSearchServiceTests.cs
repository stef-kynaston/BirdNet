using BirdNet.Data.Entities;
using BirdNet.Data.Repositories;
using BirdNet.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BirdNet.UnitTests;

public class BirdSearchServiceTests
{
    private static AppDbContext _dbContext = null!;
    private static BirdSearchService _birdSearchService = null!;

    [SetUp]
    public void Setup()
    {
        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(@"Data Source=..\..\..\..\BirdNet.App\Data\Repositories\BirdNet.db")
            .Options;
        
        _dbContext = new AppDbContext(options);
        _birdSearchService = new BirdSearchService(_dbContext);
    }
    
    [TearDown]
    public void TearDown()
    {
        _dbContext.Dispose();
    }

    [Test]
    public async Task TestSearchSpeciesByCommonName()
    {
        List<Species> results = await _birdSearchService.SearchSpeciesByCommonNameAsync("tit");
        TestContext.WriteLine($"Found {results.Count} BIRB");
        foreach (Species species in results)
        {
            TestContext.WriteLine($"Common name: {species.CommonNameSingle}, Scientific name: {species.ScientificName}");
        }
    }
    
    [Test]
    public async Task TestSearchSpeciesByScientificName()
    {
        List<Species> results = await _birdSearchService.SearchSpeciesByScientificNameAsync("rufous");
        TestContext.WriteLine($"Found {results.Count} BIRB");
        foreach (Species species in results)
        {
            TestContext.WriteLine($"Common name: {species.CommonNameSingle}, Scientific name: {species.ScientificName}");
        }
    }
}