using CSharpFunctionalExtensions;

namespace PasswordManager.Core;

public class EmailAddressPassword : BaseEntity<int>
{
    private EmailAddressPassword(string emailAddress, string password)
    {
        EmailAddress = new EmailAddress(emailAddress);
        Password = new Password(password);
    }

    public EmailAddressPassword() { }

    public EmailAddress EmailAddress { get; }

    public Password Password { get; }

    public static Result<EmailAddressPassword> Create(string email, string password)
    {
        try
        {
            var emailObject = new EmailAddress(email);
        }
        catch (Exception ex)
        {
            return Result.Failure<EmailAddressPassword>(ex.Message);
        }

        try
        {
            var passwordObject = new Password(password);
        }
        catch (Exception ex)
        {
            return Result.Failure<EmailAddressPassword>(ex.Message);
        }

        var emailAddressPassword = new EmailAddressPassword(email, password);
        return Result.Success(emailAddressPassword);
    }
}
