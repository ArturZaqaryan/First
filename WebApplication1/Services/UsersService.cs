using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class UsersService
{
    public string CheckAutorization(IHeaderDictionary headers)
    {
        if (!headers.TryGetValue("x-api-key", out var apiKey) ||
                apiKey != "reqres_902cbf1ee1eb4a4db6ed8ef5f4abde48")
        {
            return  "invalid_api_key";
        }

        return null;
    }
}
