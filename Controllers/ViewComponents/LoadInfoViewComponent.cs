using BadmintonHubWeb.Models;
using BadmintonHubWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHubWeb.Controllers.ViewComponents
{
    public class LoadInfoViewComponent : ViewComponent
    {
        private readonly IBadmintonHubAPIService _apiService;

        public LoadInfoViewComponent(IBadmintonHubAPIService apiService) => _apiService = apiService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            InfoViewModel info = await _apiService.GetInfoAsync() ?? new InfoViewModel
            {
                Name = "Elite Cuts Salon",
                Description = "Elite Cuts Salon offers premium hair services tailored to your style. Our experienced stylists provide top-notch haircuts, coloring, and styling in a modern, relaxing environment.",
                Phone = "(555) 123-4567",
                Email = "contact@elitecutssalon.com",
                WorkingTime = "Close in 1h30m",
                Address = "1234 Fashion Avenue, New York, NY 10001"
            };

            return View(info);
        }
    }
}
