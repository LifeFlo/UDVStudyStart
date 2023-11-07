namespace UdvBackend.DataBase.Entities.Account;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public static  Role From(string role)
    {
        return new()
        {
            Name = role,
            Id = Guid.NewGuid()
        };
    }
}