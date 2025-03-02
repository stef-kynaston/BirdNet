using BirdNet.Data.Repositories;

namespace BirdNet.Services;

public class BirdSearchService
{
    private readonly AppDbContext _dbContext;
    
    public BirdSearchService(AppDbContext dbContext)
    {
       _dbContext = dbContext;
    }
}