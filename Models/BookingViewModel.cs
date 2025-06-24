namespace BadmintonHubWeb.Models
{
    public class BookingViewModel
    {
        public FindAvailableCourtsViewModel FindCourts { get; set; } = new FindAvailableCourtsViewModel();
        public List<MenuViewModel>? Menu { get; set; }
        
    }
}
