using WebApplication1.Models;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Simple;

public class UsersService : IUsersService
{
    private readonly List<User> users =
            [
                new User()
                {
                    Id = 1,
                    Name = "Test",
                    Username = "Test",
                    Email = "Test"
                },
                new User()
                {
                    Id = 2,
                    Name = "Test 2",
                    Username = "Test 2",
                    Email = "Test 2"
                },
                new User()
                {
                    Id = 3,
                    Name = "Test 3",
                    Username = "Test 3",
                    Email = "Test 3"
                },
            ];

    public Task<string> CheckAutorization(IHeaderDictionary headers)
    {
        if (!headers.TryGetValue("x-api-key", out var apiKey) ||
                apiKey != "reqres_902cbf1ee1eb4a4db6ed8ef5f4abde48")
        {
            return Task.FromResult("invalid_api_key");
        }

        return null;
    }

    public Task<User> GetAsync(int id)
    {
        return Task.FromResult(users.FirstOrDefault(u => u.Id == id));
    }

    public Task<int> AddAsync(User user)
    {
        user.Id = Random.Shared.Next(1, 1000);
        users.Add(user);

        return Task.FromResult(user.Id);
    }

    public Task<int> EditOrAddAsync(int id, User user)
    {
        var findUser = users.FirstOrDefault(u => u.Id == id);

        if (findUser == null)
        {
            return AddAsync(user);
        }

        Map(user, findUser);
        return Task.FromResult(-1);
    }

    private void Map(User sourceUser, User targetUser)
    {
        targetUser.Name = sourceUser.Name;
        targetUser.Email = sourceUser.Email;
        targetUser.Username = sourceUser.Username;
    }
}
