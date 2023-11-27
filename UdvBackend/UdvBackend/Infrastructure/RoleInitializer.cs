using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Repositories;

namespace UdvBackend.Infrastructure;

public class RoleInitializer
{
    private static readonly string BaseAdminName = "Nikita";
    private static readonly string BasePasswordAdmin = "123123"; //todo: запилить получение через переменные окружения винды!!!
    private static readonly string BaseAdminEmail = "turnickii.n@gmail.com";
    public static async Task InitializeAsync(IRoleRepository roles, IAccountRepository accounts)
    {
        if (await roles.Get(Roles.HR) == null)
        {
            var role = Role.From(Roles.HR);
            await roles.Add(role);
        }
     
        if (await roles.Get(Roles.Employee) == null)
        {
            var role = Role.From(Roles.Employee);
            await roles.Add(role);
        }

        var newUser = new RequestNewHr()
        {
            Name = BaseAdminName,
            Email = BaseAdminEmail,
            Password = BasePasswordAdmin
        };
        
        var adminRole = await roles.Get(Roles.HR);
        if (adminRole == null)
        {
            throw new Exception("RoleAdmin not Created");
        }

        var admin = await accounts.Get("Nikita");
        if (admin.Value != null) return;
        
        var account = Account.From(newUser, adminRole);
        await accounts.Add(account);
    }
}