using System.ComponentModel.DataAnnotations;

namespace MappyLocationApi.Models.Requests
{
    public class FavoriteLocationCreationRequest
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Coordinates Coordinates { get; set; }
    }
}