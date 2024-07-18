namespace PasswordManager.Core;

public class WebAddressPassword : BaseEntity<int>
{
    public EmailAddress EmailAddress { get; set; }

    public Password Password { get; set; }
}
