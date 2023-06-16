using System.ComponentModel.DataAnnotations;

namespace MappyLocationApi.Models
{
    public class FavoriteLocationModel : Coordinates
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}