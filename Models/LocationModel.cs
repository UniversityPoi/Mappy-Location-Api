using System.ComponentModel.DataAnnotations;

namespace MappyLocationApi.Models
{
    public class LocationModel : Coordinates
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}