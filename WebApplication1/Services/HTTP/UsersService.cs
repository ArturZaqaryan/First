using WebApplication1.Clients;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.HTTP;

public class UsersService(UsersClient usersClient) : IUsersService
{
    private readonly UsersClient usersClient = usersClient;
    public User Get(int id)
    {
        return this.usersClient.Get(id).Result;
    }

    public int Add(User user)
    {
        return this.usersClient.Add(user).Result;
    }

    public int EditOrAdd(int id, User user)
    {
        return this.usersClient.Put(id, user).Result;
    }

    private void Map(User sourceUser, User targetUser)
    {
        targetUser.Name = sourceUser.Name;
        targetUser.Email = sourceUser.Email;
        targetUser.Username = sourceUser.Username;
    }

    public string CheckAutorization(IHeaderDictionary headers)
    {
        throw new NotImplementedException();
    }
}
