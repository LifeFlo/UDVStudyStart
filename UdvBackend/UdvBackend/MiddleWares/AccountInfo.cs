using EduControl.DataBase.ModelBd;

namespace EduControl.MiddleWare;

public class AccountInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Surname { get; set; } //todo: заменить на lastName
    public string? MiddleName { get; set; }
    public string Email { get; set; }
    public string[] Roles { get; set; } // реализовано через массив, для того, что я в будущем мог сувать разные роли в одного пользователя.

    
    public static AccountInfo From(Account account, string[] roles)
        => new ()
        {
            Email = account.Email,
            MiddleName = account.MiddleName,
            Surname = account.Surname,
            Id = account.Id,
            Name = account.Name,
            Roles = roles
        };
}