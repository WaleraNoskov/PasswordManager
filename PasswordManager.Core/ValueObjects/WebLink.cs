using System.Text.RegularExpressions;

namespace PasswordManager.Core;

public class WebLink : ValueObject
{
    public string Value { get; }
    public WebLink(string webLink)
    {
        var regex = new Regex(@"\w+.\w+");

        if (regex.IsMatch(webLink))
            Value = webLink;
        else
            throw new ArgumentException("Invalid web link format");
    }

    public WebLink()
    {
        Value = string.Empty;
    }

}
