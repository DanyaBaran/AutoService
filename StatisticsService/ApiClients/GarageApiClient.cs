using AutoService.Shared.Models;

namespace StatisticsService.Api.ApiClients
{
    public class GarageApiClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string ApiUrl = "https://localhost:7274/api/cars";

        public async Task<List<Car>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Car>>(ApiUrl);
        }
    }
}
