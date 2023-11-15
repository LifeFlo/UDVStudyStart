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
        if (await roles.Get(Roles.Admin) == null)
        {
            var role = Role.From(Roles.Admin);
            await roles.Add(role);
        }
     
        if (await roles.Get(Roles.User) == null)
        {
            var role = Role.From(Roles.User);
            await roles.Add(role);
        }

        var newUser = new RequestNewAccount()
        {
            Name = BaseAdminName,
            Email = BaseAdminEmail,
            Password = BasePasswordAdmin
        };
        var adminRole = await roles.Get(Roles.Admin);
        if (adminRole == null)
        {
            throw new Exception("RoleAdmin not Created");
        }
        
        var account = Account.From(newUser, adminRole);
        await accounts.Add(account);
    }
}