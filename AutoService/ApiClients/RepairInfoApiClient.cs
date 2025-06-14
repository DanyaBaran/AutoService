using AutoService.Shared.Models;
using System.Net.Http.Json;
using System.Web;

public class RepairInfoApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string ApiUrl = "https://localhost:7045/api/repairinfos";

    public async Task<List<RepairInfo>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<List<RepairInfo>>(ApiUrl);

    public async Task<List<RepairInfo>> SearchAsync(string query) =>
        await _httpClient.GetFromJsonAsync<List<RepairInfo>>($"{ApiUrl}/search?query={HttpUtility.UrlEncode(query)}");

    public async Task AddAsync(RepairInfo repairInfo) =>
        (await _httpClient.PostAsJsonAsync(ApiUrl, repairInfo)).EnsureSuccessStatusCode();

    public async Task UpdateAsync(RepairInfo repairInfo) =>
        (await _httpClient.PutAsJsonAsync($"{ApiUrl}/{repairInfo.RepairId}", repairInfo)).EnsureSuccessStatusCode();

    public async Task DeleteAsync(int id) =>
        (await _httpClient.DeleteAsync($"{ApiUrl}/{id}")).EnsureSuccessStatusCode();
}