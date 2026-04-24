using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Simple;

public class PostsService : IPostsService
{
    private readonly List<Post> posts =
            [
                new Post()
                {
                    UserId = 1,
                    Id = 2,
                    Title = "qui est esse",
                    Body  = "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
                },
                new Post()
                {
                    UserId = 1,
                    Id = 1,
                    Title = "qui est esse",
                    Body  = "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
                },
                new Post()
                {
                    UserId = 1,
                    Id = 4,
                    Title = "Title 1",
                    Body  = "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
                },
                new Post()
                {
                    UserId = 2,
                    Id = 3,
                    Title = "Title 3",
                    Body  = "estiae ut reiciendis\nqui aperiam non debitis possimus qui neque"
                }
            ];

    public Task<IEnumerable<Post>> GetByUserAndTitleAsync(int userId, string title = "")
    {
        return Task.FromResult(posts.Where(u => u.UserId == userId && (string.IsNullOrWhiteSpace(title) || u.Title == title)));
    }

    public Task<Post> GetByIdAsync(int id)
    {
        return Task.FromResult(posts.FirstOrDefault(u => u.Id == id));
    }

    public Task Delete(int id)
    {
        posts.Remove(posts.FirstOrDefault(u => u.Id == id));
        return Task.CompletedTask;
    }
}
