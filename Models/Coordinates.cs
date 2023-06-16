using System.ComponentModel.DataAnnotations;

namespace MappyLocationApi.Models
{
    public class Coordinates
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}