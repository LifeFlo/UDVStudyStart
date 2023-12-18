using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using UdvBackend.Controllers.AdminController.Model;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Domen.Entities;
using UdvBackend.Infrastructure.Extnentions;
using UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;
using UdvBackend.Repositories;
using Task = System.Threading.Tasks.Task;

namespace UdvBackend.Infrastructure;

public class RoleInitializers //todo: можно рефакторнуть
{
    private static readonly string BaseAdminName = "Nikita";

    private static readonly string
        BasePasswordAdmin = "123123"; //todo: запилить получение через переменные окружения винды!!!

    private static readonly string BaseAdminEmail = "turnickii.n@gmail.com";
    private static readonly string BaseMiddleName = "Alex";
    private static readonly string BaseLastName = "Turnitsky";

    public async Task InitializeAsync(IRoleRepository roles, IAccountRepository accounts,  ILinkEmployeesHr employeesHr)
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
        if (!admin.Exist())
        {
            var account = Account.From(newUser, adminRole.Id);
            await accounts.Add(account);
            admin = account;
        }

        var emplo = await accounts.Get("udv@mail.com");
       
        if (!emplo.Exist())
        {
            var empoloyee = CreateEmployee();
            await accounts.Add(empoloyee);
            await employeesHr.Connect(HREmployees.From(admin, empoloyee));
        }
    }

    private static Account CreateEmployee()
    {
        var password = "123123";
        var empoloyees = Account.From(new RequestNewEmployee()
        {
            Email = "udv@mail.com", MiddleName = "Журавлёв", Name = "Vadim", Surname = "heruco"
        }, Roles.Employee.Id, password);
        return empoloyees;
    }
    

    private async Task AddAndSetRole(string nameRole, IRoleRepository roles, Action<Guid> action)
    {
        var role = await roles.Get(nameRole);
        if (role == null)
        {
            role = Role.From(nameRole);
            await roles.Add(role);
        }

        action(role.Id);
    }
}