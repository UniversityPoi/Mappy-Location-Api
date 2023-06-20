using Microsoft.AspNetCore.Mvc;
using MappyLocationApi.Services;
using MappyLocationApi.Models;
using MappyLocationApi.Models.Requests;

namespace MappyUserApi.Controllers
{
  [Route("api/favorite-location")]
  [ApiController]
  public class FavoriteLocationController : ControllerBase
  {

    //=============================================================================================
    private readonly FavoriteLocationService _favoriteLocationService;


    //=============================================================================================
    public FavoriteLocationController(FavoriteLocationService favoriteLocationService)
    {
      _favoriteLocationService = favoriteLocationService;
    }


    //=============================================================================================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
      var location = await _favoriteLocationService.GetAsync(id);

      if (location is null)
      {
        return NotFound(new { message = $"No location with id {id} exist!" });
      }
      else
      {
        return Ok(location);
      }
    }


    //=============================================================================================
    [HttpGet("user/{id}")]
    public IActionResult GetAllByUser(Guid id)
    {
      var locations = _favoriteLocationService.GetAllByUser(id);

      return Ok(locations);
    }


    //=============================================================================================
    [HttpPost("")]
    public async Task<IActionResult> Add(FavoriteLocationCreationRequest location)
    {
      var doesLocationWithThatNameExist =  
        (await _favoriteLocationService.GetByNameAsync(location.UserId, location.Name))
        is not null;

      if (doesLocationWithThatNameExist)
      {
        return BadRequest(new { message = $"Location with name {location.Name} already exist!" });
      }

      var result = await _favoriteLocationService.AddAsync(new FavoriteLocationModel
      {
        UserId = location.UserId,
        Name = location.Name,
        Latitude = location.Coordinates.Latitude,
        Longitude = location.Coordinates.Longitude,
        Date = DateTime.Now
      });

      if (result is null)
      {
        return BadRequest(new { message = $"Cannot create the location!" });
      }
      else
      {
        return Ok(result);
      }
    }


    //=============================================================================================
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
      var location = await _favoriteLocationService.DeleteAsync(id);

      if (location is null)
      {
        return NotFound(new { message = $"No location with id {id} exist!" });
      }
      else
      {
        return Ok(location);
      }
    }
  }
}