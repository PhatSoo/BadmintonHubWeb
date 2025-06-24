using System.ComponentModel.DataAnnotations;

namespace BadmintonHubWeb.Models
{
    public class MenuViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty ;
    }
}
