namespace PasswordManager.Core;

public class WebLinkPassword : BaseEntity<int>
{
    public WebLink WebLink { get; set; }

    public Password Password { get; set; }
}
