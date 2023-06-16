using MappyLocationApi.Models;
using MappyLocationApi.Repos;
using Microsoft.EntityFrameworkCore;

namespace MappyLocationApi.Services
{
  public class LocationService
  {
    //=============================================================================================
    private readonly LocationDbContext _db;


    //=============================================================================================
    public LocationService(LocationDbContext dbContext)
    {
      _db = dbContext;
    }

  
    //=============================================================================================
    public async Task<LocationModel> AddAsync(LocationModel location)
    {
      var result = await _db.Locations.AddAsync(location);

      await _db.SaveChangesAsync();

      return result.Entity;
    }


    //=============================================================================================
    public async Task<LocationModel?> GetAsync(Guid id)
    {
      return await _db.Locations.FirstOrDefaultAsync(location => location.Id == id);
    }


    //=============================================================================================
    public async Task<LocationModel?> GetLastByUserAsync(Guid userId)
    {
      var location = await _db.Locations
        .Where(l => l.UserId == userId)
        .OrderByDescending(l => l.Date)
        .FirstOrDefaultAsync();

      return location;
    }
  }
}