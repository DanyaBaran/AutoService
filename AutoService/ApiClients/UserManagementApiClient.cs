using AutoService.Shared.Models;
using System.Net.Http.Json;

public record UpdateAdminStatusRequest(bool IsAdmin);

public class UserManagementApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string ApiUrl = "https://localhost:7068/api/users";

    public async Task<List<User>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<User>>(ApiUrl);
    }

    public async Task UpdateAdminStatusAsync(int userId, bool newIsAdminStatus)
    {
        var request = new UpdateAdminStatusRequest(newIsAdminStatus);
        var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{userId}", request);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}