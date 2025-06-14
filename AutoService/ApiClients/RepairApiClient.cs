using AutoService.Shared.Models;
using System.Net.Http.Json;
using System.Web;

public class RepairApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string ApiUrl = "https://localhost:7045/api/repairs";

    public async Task<List<Repair>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<List<Repair>>(ApiUrl);

    public async Task<List<Repair>> SearchAsync(string query) =>
        await _httpClient.GetFromJsonAsync<List<Repair>>($"{ApiUrl}/search?query={HttpUtility.UrlEncode(query)}");

    public async Task AddAsync(Repair repair) =>
        (await _httpClient.PostAsJsonAsync(ApiUrl, repair)).EnsureSuccessStatusCode();

    public async Task UpdateAsync(Repair repair) =>
        (await _httpClient.PutAsJsonAsync($"{ApiUrl}/{repair.IdRepair}", repair)).EnsureSuccessStatusCode();

    public async Task DeleteAsync(int id) =>
        (await _httpClient.DeleteAsync($"{ApiUrl}/{id}")).EnsureSuccessStatusCode();
}