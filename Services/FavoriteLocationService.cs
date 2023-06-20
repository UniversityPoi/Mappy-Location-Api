using MappyLocationApi.Models;
using MappyLocationApi.Repos;
using Microsoft.EntityFrameworkCore;

namespace MappyLocationApi.Services
{
  public class FavoriteLocationService
  {
    //=============================================================================================
    private readonly LocationDbContext _db;


    //=============================================================================================
    public FavoriteLocationService(LocationDbContext dbContext)
    {
      _db = dbContext;
    }


    //=============================================================================================
    public async Task<FavoriteLocationModel> AddAsync(FavoriteLocationModel location)
    {
      var result = await _db.FavoriteLocations.AddAsync(location);

      await _db.SaveChangesAsync();

      return result.Entity;
    }


    //=============================================================================================
    public async Task<FavoriteLocationModel?> GetAsync(Guid id)
    {
      return await _db.FavoriteLocations.FirstOrDefaultAsync(location => location.Id == id);
    }


    //=============================================================================================
    public IEnumerable<FavoriteLocationModel> GetAllByUser(Guid userId)
    {
      return _db.FavoriteLocations
        .Where(location => location.UserId == userId)
        .AsEnumerable();
    }


    //=============================================================================================
    public async Task<FavoriteLocationModel?> GetByNameAsync(Guid userId, string name)
    {
      return await _db.FavoriteLocations.FirstOrDefaultAsync(location => 
        location.UserId == userId && location.Name == name);
    }


    //=============================================================================================
    public async Task<FavoriteLocationModel?> DeleteAsync(Guid id)
    {
      var location = await GetAsync(id);

      if (location is not null)
      {
        _db.Remove(location);
      }

      return location;
    }
  }
}