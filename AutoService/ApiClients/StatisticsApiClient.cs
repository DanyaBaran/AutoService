using System.Net.Http.Json;

public class StatisticsApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string ApiUrl = "https://localhost:7208/api/statistics";

    public async Task<Dictionary<int, int>> GetRepairsPerMonthAsync() =>
        await _httpClient.GetFromJsonAsync<Dictionary<int, int>>($"{ApiUrl}/repairs-per-month");

    public async Task<Dictionary<int, int>> GetRepairsPerYearAsync() =>
        await _httpClient.GetFromJsonAsync<Dictionary<int, int>>($"{ApiUrl}/repairs-per-year");

    public async Task<Dictionary<string, int>> GetPopularCarMarksAsync() =>
        await _httpClient.GetFromJsonAsync<Dictionary<string, int>>($"{ApiUrl}/popular-marks");
}