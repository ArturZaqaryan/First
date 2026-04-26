using WebApplication1.Models;

namespace WebApplication1.Repositories.Abstract
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> Get();
        User GetById(int id);
    }
}