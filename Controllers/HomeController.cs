using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BadmintonHubWeb.Models;
using BadmintonHubWeb.Services;
using System.Threading.Tasks;

namespace BadmintonHubWeb.Controllers;

public class HomeController : Controller
{
    private readonly IBadmintonHubAPIService _apiService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IBadmintonHubAPIService apiService)
    {
        _logger = logger;
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var menus = await _apiService.GetAllMenus();
        return View(new BookingViewModel()
        {
            Menu = menus,
        });
    }

    public async Task<JsonResult> FindAvailableCourts([FromBody]FindAvailableCourtsViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new { success = false, errors = ModelState.ToDictionary(m => m.Key, m => m.Value.Errors.Select(e => e.ErrorMessage).ToList()) });
        }

        var availableCourts = await _apiService.GetAvailableCourts(model);
        return Json(new { success = true, message = "Found", availableCourts });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
