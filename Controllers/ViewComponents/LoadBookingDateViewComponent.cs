using BadmintonHubWeb.Models;
using BadmintonHubWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHubWeb.Controllers.ViewComponents
{
    public class LoadBookingDateViewComponent : ViewComponent
    {
        private readonly IBadmintonHubAPIService _apiService;

        public LoadBookingDateViewComponent(IBadmintonHubAPIService apiService) => _apiService = apiService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var closedDates = await _apiService.GetCloseDates();

            var viewModel = new List<FieldClourseViewModel> (closedDates);

            return View(viewModel);
        }
    }
}
