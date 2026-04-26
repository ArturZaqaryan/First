using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Abstract;

namespace WebApplication1.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> users = [];

    public void CheckDuplicates(User user)
    {
        if (users.Count > 0)
        {
            if (users.Any(u => u.Username == user.Username))
            {
                throw new DuplicateException("User with specified Username already exists.");
            }
        }
    }

    public void Add(User user)
    {
        CheckDuplicates(user);
        users.Add(user);
    }

    public List<User> Get()
    {
        return users;
    }

    public User GetById(int id)
    {
        return users.FirstOrDefault(u => u.Id == id);
    }
}
