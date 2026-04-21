using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Simple;

public class UsersService(UserRepository userRepository) : IUsersService
{
    private readonly UserRepository userRepository = userRepository;

    public string CheckAutorization(IHeaderDictionary headers)
    {
        if (!headers.TryGetValue("x-api-key", out var apiKey) ||
                apiKey != "reqres_902cbf1ee1eb4a4db6ed8ef5f4abde48")
        {
            return "invalid_api_key";
        }

        return null;
    }

    public User Get(int id)
    {
        return userRepository.GetById(id);
    }

    public int Add(User user)
    {
        user.Id = Random.Shared.Next(1, 1000);
        userRepository.Add(user);

        return user.Id;
    }

    public int EditOrAdd(int id, User user)
    {
        var findUser = userRepository.Get().FirstOrDefault(u => u.Id == id);

        if (findUser == null)
        {
            return Add(user);
        }

        Map(user, findUser);

        return -1;
    }

    private void Map(User sourceUser, User targetUser)
    {
        targetUser.Name = sourceUser.Name;
        targetUser.Email = sourceUser.Email;
        targetUser.Username = sourceUser.Username;
    }
}
