namespace EduControl;

public class AccountIdentity
{
    public string Name { get; set; }
    public string Email { get; set; }

    public AccountIdentity(string name, string email)
    {
        Name = name;
        Email = email;
    }
}