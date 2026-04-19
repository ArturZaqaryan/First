using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class UserRepository
{
    private List<UserRegister> users = [];

    public void CheckDuplicates(UserRegister user)
    {
        if (users.Count > 0)
        {
            if (users.Any(u => u.Username == user.Username))
            {
                throw new Exception("User with specified Username already exists.");
            }
        }
    }

    public void AddUser(UserRegister user)
    {
        CheckDuplicates(user);
        users.Add(user);
    }
}
