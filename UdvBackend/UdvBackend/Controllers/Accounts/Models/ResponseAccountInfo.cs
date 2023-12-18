using EduControl.DataBase.ModelBd;
using UdvBackend.Infrastructure.Extnentions;

namespace EduControl.Controllers.Model;

public class ResponseAccountInfo
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public static ResponseAccountInfo From(Account account, string role)
        => new()
        {
            Name = account.Name,
            MiddleName = account.MiddleName,
            Email = account.Email,
            Surname = account.Surname,
            Role = role
        };
}