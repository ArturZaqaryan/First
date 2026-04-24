using WebApplication1.Clients;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.HTTP;

public class UsersService(UsersClient usersClient) : IUsersService
{
    private readonly UsersClient usersClient = usersClient;
    public async Task<User> GetAsync(int id)
    {
        return await this.usersClient.Get(id);
    }

    public async Task<int> AddAsync(User user)
    {
        return await usersClient.Add(user);
    }

    public async Task<int> EditOrAddAsync(int id, User user)
    {
        return await this.usersClient.Put(id, user);
    }

    public Task<string> CheckAutorization(IHeaderDictionary headers)//TODO: Ճիշտ ձևը իմանալուց հետո կկորի սա ։)
    {
        throw new NotImplementedException();
    }
}
