using BadmintonHubWeb.Models.CustomAnnotation;
using System.ComponentModel.DataAnnotations;

namespace BadmintonHubWeb.Models
{
    public class FindAvailableCourtsViewModel
    {
        [Required(ErrorMessage = "Please select Start time")]
        public string StartTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select End time")]
        [CompareTimeValidation(nameof(StartTime))]
        public string EndTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a date.")]
        public DateTime? SelectedDate { get; set; }
    }
}
