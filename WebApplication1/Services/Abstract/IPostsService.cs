using WebApplication1.Models;

namespace WebApplication1.Services.Abstract
{
    public interface IPostsService
    {
        void Delete(int id);
        Post GetById(int id);
        IEnumerable<Post> GetByUserAndTitle(int userId, string title = "");
    }
}