using WebApplication1.Models;

namespace WebApplication1.Services;

public class UsersService
{
    public UserErrorResponse CheckAutorization(IHeaderDictionary headers)
    {
        if (!headers.TryGetValue("x-api-key", out var apiKey) ||
                apiKey != "reqres_902cbf1ee1eb4a4db6ed8ef5f4abde48")
        {
            return new UserErrorResponse()
            {
                Error = "invalid_api_key",
                Message = "This API key is not recognized or has been revoked.",
                Hint = "Check that your API key is correct and not expired.",
                NextSteps = new List<string>()
                    {
                        "Verify the key in your dashboard at app.reqres.in/api-keys",
                        "Regenerate the key if needed",
                        "Ensure you're using the correct key type (manage/public)"
                    },
                DocsUrl = "https://app.reqres.in/docs#api-keys",
                Meta = new Meta()
                {
                    PoweredBy = "ReqRes",
                    DocsUrl = "https://app.reqres.in/documentation",
                    UpgradeUrl = "https://app.reqres.in/upgrade",
                    ExampleUrl = "https://app.reqres.in/examples/notes-app",
                    Variant = "v1_b",
                    Message = "Missing/invalid key. Grab a free key to keep responses consistent.",
                    Cta = new Cta()
                    {
                        Label = "Get started",
                        Url = "https://app.reqres.in/api-keys"
                    },
                    Context = "invalid_key"
                }
            };
        }

        return null;
    }
}
