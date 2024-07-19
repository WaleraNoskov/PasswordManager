using CSharpFunctionalExtensions;

namespace PasswordManager.Core;

public class WebLinkPassword : BaseEntity<int>
{
    private WebLinkPassword(string link, string password)
    {
        WebLink = new WebLink(link);
        Password = new Password(password);
    }

    public WebLink WebLink { get; set; }

    public Password Password { get; set; }

    public static Result<WebLinkPassword> Create(string link, string password)
    {
        try
        {
            var linkObject = new WebLink(link);
        }
        catch (Exception ex)
        {
            return Result.Failure<WebLinkPassword>(ex.Message);
        }

        try
        {
            var passwordObject = new Password(password);
        }
        catch (Exception ex)
        {
            return Result.Failure<WebLinkPassword>(ex.Message);
        }

        var webLinkPassword = new WebLinkPassword(link, password);
        return Result.Success(webLinkPassword);
    }
}
