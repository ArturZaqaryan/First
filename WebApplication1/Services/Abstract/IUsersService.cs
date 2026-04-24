using WebApplication1.Models;

namespace WebApplication1.Services.Abstract;

public interface IUsersService
{
    Task<string> CheckAutorization(IHeaderDictionary headers);
    Task<User> GetAsync(int id);
    Task<int> AddAsync(User user);
    Task<int> EditOrAddAsync(int id, User user);
}
