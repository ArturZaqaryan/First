using WebApplication1.Models;

namespace WebApplication1.Services.Abstract;

public interface IUsersService
{
    string CheckAutorization(IHeaderDictionary headers);
    User Get(int id);
    int Add(User user);
    int EditOrAdd(int id, User user);
}
