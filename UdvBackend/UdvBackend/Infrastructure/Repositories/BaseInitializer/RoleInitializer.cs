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
        await AddAndSetRole(Roles.HR.NameRole, roles, Roles.CreateHRRoleSingleton);
        await AddAndSetRole(Roles.Employee.NameRole, roles, Roles.CreateEmployeeRoleSingleton);
        
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

    private async Task AddAndSetRole(string NameRole, IRoleRepository roles, Action<Guid> action)
    {
        var role = await roles.Get(NameRole);
        if (role == null)
        {
            role = Role.From(Roles.HR.NameRole);
            await roles.Add(role);
        }

        action(role.Id);
    }
}