using System.Text.RegularExpressions;

namespace PasswordManager.Core;

public class Password
{
    public string Value { get; }

    public Password(string password)
    {
        var regex = new Regex(@"\w+\W+");

        if (regex.IsMatch(password))
            Value = password;
        else
            throw new ArgumentException("Invalid password format");
    }

    public Password()
    {
        Value = string.Empty;
    }
}
