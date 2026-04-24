using WebApplication1.Clients;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.HTTP;

public class PostsService(PostsClient postsClient) : IPostsService
{
    private readonly PostsClient postsClient = postsClient;
    public async Task<IEnumerable<Post>> GetByUserAndTitleAsync(int userId, string title = "")
    {
        return await this.postsClient.GetByUserAndTitle(userId,title);
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        return await this.postsClient.GetById(id);
    }

    public async Task Delete(int id)
    {
        await this.postsClient.Delete(id);
    }
}
