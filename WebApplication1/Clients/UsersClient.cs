using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Clients;

public class UsersClient(HttpClient httpClient) : HttpClient
{
    private readonly HttpClient httpClient = httpClient;
    public async Task<User> Get(int id)
    {
        return await this.httpClient.GetFromJsonAsync<User>($"users/{id}");
    }

    public async Task<int> Add(User user)
    {
        var response = await this.httpClient.PostAsJsonAsync("users/", user);
        response.EnsureSuccessStatusCode();
        string respContent = await response.Content.ReadAsStringAsync();

        User respUser = JsonSerializer.Deserialize<User>(respContent, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
        });
        return respUser is null ? throw new Exception("Internal Server error.") : respUser.Id;
    }

    public async Task<int> Put(int id, User user)
    {
        var response = await this.httpClient.PutAsJsonAsync($"users/{id}", user);
        response.EnsureSuccessStatusCode();
        string respContent = await response.Content.ReadAsStringAsync();

        User respUser = JsonSerializer.Deserialize<User>(respContent, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
        });
        return respUser is null ? throw new Exception("Internal Server error.") : respUser.Id;
    }
}
