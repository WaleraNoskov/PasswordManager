using CSharpFunctionalExtensions;

namespace PasswordManager.Core;

public class WebAddressPassword : BaseEntity<int>
{
    private WebAddressPassword(string emailAddress, string password)
    {
        EmailAddress = new EmailAddress(emailAddress);
        Password = new Password(password);
    }

    public EmailAddress EmailAddress { get; }

    public Password Password { get; }

    public static Result<WebAddressPassword> Create(string email, string password)
    {
        try
        {
            var emailObject = new EmailAddress(email);
        }
        catch (Exception ex)
        {
            return Result.Failure<WebAddressPassword>(ex.Message);
        }

        try
        {
            var passwordObject = new Password(password);
        }
        catch (Exception ex)
        {
            return Result.Failure<WebAddressPassword>(ex.Message);
        }

        var webAddressPassword = new WebAddressPassword(email, password);
        return Result.Success(webAddressPassword);
    }
}
