using AutoService.Shared.Models;
using System.Net.Http.Json;
using System.Web;

public class AssemblyApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string ApiUrl = "https://localhost:7274/api/assemblies";

    public async Task<List<Assembly>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<List<Assembly>>(ApiUrl);

    public async Task<List<Assembly>> SearchAsync(string query) =>
        await _httpClient.GetFromJsonAsync<List<Assembly>>($"{ApiUrl}/search?query={HttpUtility.UrlEncode(query)}");

    public async Task AddAsync(Assembly assembly) =>
        (await _httpClient.PostAsJsonAsync(ApiUrl, assembly)).EnsureSuccessStatusCode();

    public async Task UpdateAsync(Assembly assembly) =>
        (await _httpClient.PutAsJsonAsync($"{ApiUrl}/{assembly.IdAssembly}", assembly)).EnsureSuccessStatusCode();

    public async Task DeleteAsync(int id) =>
        (await _httpClient.DeleteAsync($"{ApiUrl}/{id}")).EnsureSuccessStatusCode();
}