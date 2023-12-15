using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Infrastructure.Extnentions;
using UdvBackend.Repositories;

namespace UdvBackend.Infrastructure;

public class RoleInitializers //todo: можно рефакторнуть
{
    private static readonly string BaseAdminName = "Nikita";

    private static readonly string
        BasePasswordAdmin = "123123"; //todo: запилить получение через переменные окружения винды!!!

    private static readonly string BaseAdminEmail = "turnickii.n@gmail.com";
    private static readonly string BaseMiddleName = "Alex";
    private static readonly string BaseLastName = "Turnitsky";

    public async Task InitializeAsync(IRoleRepository roles, IAccountRepository accounts)
    {
        if (await roles.Get(Roles.HR.NameRole) == null)
        {
            var role = Role.From(Roles.HR.NameRole);
            Roles.CreateEmployeeRoleSingleton(role.Id);
            await roles.Add(role);
        }
        
        
        if (await roles.Get(Roles.Employee.NameRole) == null)
        {
            var role = Role.From(Roles.Employee.NameRole);
            Roles.CreateHRRoleSingleton(role.Id);
            await roles.Add(role);
        }

        var newUser = new RequestNewHr()
        {
            Name = BaseAdminName,
            Email = BaseAdminEmail,
            Password = BasePasswordAdmin,
            MiddleName = BaseMiddleName,
            LastName = BaseLastName
        };

        var adminRole = await roles.Get(Roles.HR.NameRole);
        if (adminRole == null)
        {
            throw new Exception("RoleAdmin not Created");
        }

        var admin = await accounts.Get("turnickii.n@gmail.com");
        if (admin.Exist()) return;

        var account = Account.From(newUser, adminRole.Id);
        await accounts.Add(account);
    }
}