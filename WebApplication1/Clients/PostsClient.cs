using Microsoft.AspNetCore.WebUtilities;
using WebApplication1.Models;

namespace WebApplication1.Clients;

public class PostsClient(HttpClient httpClient)
{
    private readonly HttpClient httpClient = httpClient;
    public async Task<IEnumerable<Post>> GetByUserAndTitle(int userId, string title = "")
    {
        var queryParams = new Dictionary<string, string?>
        {
            ["userId"] = userId.ToString()
        };

        if (!string.IsNullOrWhiteSpace(title))
        {
            queryParams.Add("title", title);
        }

        string uri = QueryHelpers.AddQueryString("posts", queryParams);

        return await this.httpClient.GetFromJsonAsync<IEnumerable<Post>>(uri) ?? [];
    }

    public async Task<Post> GetById(int id)
    {
        return await this.httpClient.GetFromJsonAsync<Post>($"posts/{id}");
    }

    public async Task Delete(int id)
    {
        var _ = await this.httpClient.DeleteAsync($"posts/{id}");
    }
}
