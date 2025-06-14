using AutoService.Shared.Models;
using System.Net.Http.Json;
using System.Web;

public class EmployeeApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string ApiUrl = "https://localhost:7045/api/employees";

    public async Task<List<Employee>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<List<Employee>>(ApiUrl);

    public async Task<List<Employee>> SearchAsync(string query) =>
        await _httpClient.GetFromJsonAsync<List<Employee>>($"{ApiUrl}/search?query={HttpUtility.UrlEncode(query)}");

    public async Task AddAsync(Employee employee) =>
        (await _httpClient.PostAsJsonAsync(ApiUrl, employee)).EnsureSuccessStatusCode();

    public async Task UpdateAsync(Employee employee) =>
        (await _httpClient.PutAsJsonAsync($"{ApiUrl}/{employee.IdEmployee}", employee)).EnsureSuccessStatusCode();

    public async Task DeleteAsync(int id) =>
        (await _httpClient.DeleteAsync($"{ApiUrl}/{id}")).EnsureSuccessStatusCode();
}