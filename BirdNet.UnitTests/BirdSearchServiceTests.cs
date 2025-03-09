using BirdNet.Data.Repositories;
using BirdNet.Services;
using Microsoft.EntityFrameworkCore;

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
    public void TestSearchSpeciesByCommonName()
    {
        // List<Species> results = _birdSearchService.SearchSpeciesByCommonNameAsync("tit").ToListAsync();
        // TestContext.WriteLine($"Found {results.Count} BIRB");

        // foreach (Species species in results)
        // {
        // TestContext.WriteLine(
        // $"Common name: {species.CommonNameSingle}, Scientific name: {species.ScientificName}"
        // );
        // }

        // Assert.That(results, Has.Count.EqualTo(12));
    }

    [Test]
    public void TestSearchSpeciesByScientificName()
    {
        // List<Species> results = _birdSearchService.SearchSpeciesByScientificNameAsync("rufous").ToList();
        // TestContext.WriteLine($"Found {results.Count} BIRB");
        // foreach (Species species in results)
        // {
        //     TestContext.WriteLine(
        //         $"Common name: {species.CommonNameSingle}, Scientific name: {species.ScientificName}"
        //     );
        // }
    }
}