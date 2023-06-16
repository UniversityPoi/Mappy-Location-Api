using System.Linq;
using MappyLocationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MappyLocationApi.Repos
{
    public class LocationDbContext : DbContext
    {
        //=============================================================================================
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<FavoriteLocationModel> FavoriteLocations { get; set; }
        
        
        //=============================================================================================
        public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options)
        {
            
        }
    }
}