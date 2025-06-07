using System.ComponentModel.DataAnnotations;

namespace BadmintonHubWeb.Models
{
    public class InfoViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Office Address")]
        public string Address { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Working Hours")]
        public string WorkingTime { get; set; } = string.Empty;
    }
}
