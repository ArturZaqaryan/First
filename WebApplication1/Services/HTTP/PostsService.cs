using WebApplication1.Clients;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.HTTP;

public class PostsService(PostsClient postsClient) : IPostsService
{
    private readonly PostsClient postsClient = postsClient;
    public IEnumerable<Post> GetByUserAndTitle(int userId, string title = "")
    {
        return this.postsClient.GetByUserAndTitle(userId,title).Result;
    }

    public Post GetById(int id)
    {
        return this.postsClient.GetById(id).Result;
    }

    public void Delete(int id)
    {
        this.postsClient.Delete(id);
    }
}
