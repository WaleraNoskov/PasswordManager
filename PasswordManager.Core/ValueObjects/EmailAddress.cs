using System.Text.RegularExpressions;

namespace PasswordManager.Core;

public class EmailAddress : ValueObject
{
    public string Address { get; } = string.Empty;

    public EmailAddress(string emailAddress)
    {
        var regex = new Regex(@"\w+@\w+.\w+");

        if (regex.IsMatch(emailAddress))
            Address = emailAddress;
        else
            throw new ArgumentException("Invalid email format");
    }

    public EmailAddress() { }
}
