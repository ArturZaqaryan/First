using WebApplication1.Models;

namespace WebApplication1.Clients;

public class PostsClient(HttpClient httpClient) : HttpClient
{
    private readonly HttpClient httpClient = httpClient;
    public async Task<IEnumerable<Post>> GetByUserAndTitle(int userId, string title = "")
    {
        string queryString = $"?userId={userId}";
        queryString += string.IsNullOrWhiteSpace(title) ? string.Empty : $"&title={title}";

        return await this.httpClient.GetFromJsonAsync<IEnumerable<Post>>(queryString);
    }

    public async Task<Post> GetById(int id)
    {
        return await this.httpClient.GetFromJsonAsync<Post>(id.ToString());
    }

    public void Delete(int id)
    {
        this.httpClient.DeleteAsync(id.ToString());
    }
}
