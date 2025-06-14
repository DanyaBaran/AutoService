using AutoService.Shared.Models;
using System.Net.Http.Json;

public record LoginRequest(string Username, string Password);
public record RegisterRequest(string Username, string Password);

public class AuthApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string ApiUrl = "https://localhost:7068/api/auth";

    public async Task<User> LoginAsync(LoginRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}/login", request);
        return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<User>() : null;
    }

    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}/register", request);
        return response.IsSuccessStatusCode;
    }
}