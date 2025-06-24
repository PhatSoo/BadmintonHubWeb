
using BadmintonHubWeb.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace BadmintonHubWeb.Services
{
    public class BadmintonHubAPIService : IBadmintonHubAPIService
    {
        private readonly HttpClient _httpClient;

        public BadmintonHubAPIService(HttpClient httpCLient)
        {
            _httpClient = httpCLient;
            _httpClient.BaseAddress = new Uri("https://localhost:7297/api/v1/");
        }

        public async Task<InfoViewModel?> GetInfoAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("info");

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var info = System.Text.Json.JsonSerializer.Deserialize<InfoViewModel>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return info;
            }
            
            catch (Exception ex) {
                Console.WriteLine($"Error when call API: {ex.Message}");
                return null;
            }
        }

        // Field functions
        public async Task<List<FieldClourseViewModel>> GetCloseDates()
        {
            var response = await _httpClient.GetAsync("field/closed_dates");

            if (!response.IsSuccessStatusCode)
            {
                return [];
            }

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<FieldClourseViewModel>>(json);
            return data ?? [];
        }

        // Court functions
        public async Task<List<CourtViewModel>> GetAvailableCourts(FindAvailableCourtsViewModel courts)
        {
            var response = await _httpClient.GetAsync($"courts/available-courts?date={courts.SelectedDate}&startTime={courts.StartTime}&endTime={courts.EndTime}");

            if (!response.IsSuccessStatusCode)
            {
                return [];
            }

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CourtViewModel>>(json);
            return data ?? [];
        }

        public async Task<List<MenuViewModel>> GetAllMenus()
        {
            var response = await _httpClient.GetAsync("menu");

            if (!response.IsSuccessStatusCode)
            {
                return [];
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var menus = System.Text.Json.JsonSerializer.Deserialize<List<MenuViewModel>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return menus ?? [];
        }
    }
}
