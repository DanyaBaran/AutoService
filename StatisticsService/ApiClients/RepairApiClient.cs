using AutoService.Shared.Models;

namespace StatisticsService.Api.ApiClients
{
    public class RepairApiClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string ApiUrl = "https://localhost:7045/api/repairs";

        public async Task<List<Repair>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Repair>>(ApiUrl);
        }
    }
}
