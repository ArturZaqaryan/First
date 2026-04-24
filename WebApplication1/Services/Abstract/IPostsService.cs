using WebApplication1.Models;

namespace WebApplication1.Services.Abstract
{
    public interface IPostsService
    {
        void Delete(int id);
        Task<Post> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetByUserAndTitleAsync(int userId, string title = "");
    }
}