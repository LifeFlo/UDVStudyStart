using EduControl.DataBase.ModelBd;

namespace EduControl.Controllers.Model;

public class ResponseAccountInfo
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }


    public static explicit operator ResponseAccountInfo(Account account)
        => new()
        {
            Name = account.Name,
            MiddleName = account.MiddleName,
            Email = account.Email,
            Surname = account.Surname
        };
}