using Microsoft.AspNetCore.Mvc;
using MappyLocationApi.Services;
using MappyLocationApi.Models;
using MappyLocationApi.Models.Requests;

namespace MappyUserApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationController : ControllerBase
  {

    //=============================================================================================
    private readonly LocationService _locationService;


    //=============================================================================================
    public LocationController(LocationService locationService)
    {
      _locationService = locationService;
    }


    //=============================================================================================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
      var location = await _locationService.GetAsync(id);

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
    [HttpGet("user/last/{id}")]
    public async Task<IActionResult> GetLastByUser(Guid id)
    {
      var location = await _locationService.GetLastByUserAsync(id);

      if (location is null)
      {
        return NotFound(new { message = $"No location with user id {id} exist!" });
      }
      else
      {
        return Ok(location);
      }
    }


    //=============================================================================================
    [HttpPost("")]
    public async Task<IActionResult> Add(LocationCreationRequest location)
    {
      var result = await _locationService.AddAsync(new LocationModel
      {
        UserId = location.UserId,
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
  }
}