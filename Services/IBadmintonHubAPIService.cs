using BadmintonHubWeb.Models;

namespace BadmintonHubWeb.Services
{
    public interface IBadmintonHubAPIService
    {
        Task<InfoViewModel?> GetInfoAsync();
        Task<List<FieldClourseViewModel>> GetCloseDates();
        Task<List<CourtViewModel>> GetAvailableCourts(FindAvailableCourtsViewModel courts);
        Task<List<MenuViewModel>> GetAllMenus();
    }
}
