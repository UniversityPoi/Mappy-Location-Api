using System.ComponentModel.DataAnnotations;

namespace MappyLocationApi.Models.Requests
{
    public class LocationCreationRequest
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Coordinates Coordinates { get; set; }
    }
}