using AutoService.Shared.Models;
using System.Net.Http.Json;
using System.Web;

public class CarApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string ApiUrl = "https://localhost:7274/api/cars";

    public async Task<List<Car>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<List<Car>>(ApiUrl);

    public async Task<List<Car>> SearchAsync(string query) =>
        await _httpClient.GetFromJsonAsync<List<Car>>($"{ApiUrl}/search?query={HttpUtility.UrlEncode(query)}");

    public async Task AddAsync(Car car) =>
        (await _httpClient.PostAsJsonAsync(ApiUrl, car)).EnsureSuccessStatusCode();

    public async Task UpdateAsync(Car car) =>
        (await _httpClient.PutAsJsonAsync($"{ApiUrl}/{car.IdCar}", car)).EnsureSuccessStatusCode();

    public async Task DeleteAsync(int id) =>
        (await _httpClient.DeleteAsync($"{ApiUrl}/{id}")).EnsureSuccessStatusCode();
}