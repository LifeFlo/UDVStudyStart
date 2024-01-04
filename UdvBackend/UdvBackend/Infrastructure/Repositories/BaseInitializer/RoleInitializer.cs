using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using UdvBackend.Controllers.AdminController.Model;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Domen.Entities;
using UdvBackend.Infrastructure.Extnentions;
using UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;
using UdvBackend.Repositories;
using Task = System.Threading.Tasks.Task;

namespace UdvBackend.Infrastructure.Repositories.BaseInitializer;

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
        await AddAndSetRole(Roles.Hr, roles);
        await AddAndSetRole(Roles.Employee, roles);

        var newUser = new RequestNewHr()
        {
            Name = BaseAdminName,
            Email = BaseAdminEmail,
            Password = BasePasswordAdmin,
            MiddleName = BaseMiddleName,
            LastName = BaseLastName
        };

        var adminRole = await roles.Get(Roles.Hr);
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

        var employeeRole = await roles.Get(Roles.Employee);
        if (employeeRole == null)
        {
            throw new Exception("RoleEmployee not Created");
        }
        
        var emplo = await accounts.Get("udv@mail.com");
        if (!emplo.Exist())
        {
            var empoloyee = CreateEmployee(employeeRole.Id);
            await accounts.Add(empoloyee);
            await employeesHr.Connect(HREmployees.From(admin.Id, empoloyee.Id));
        }
    }

    private static Account CreateEmployee(Guid employeeRoleId)
    {
        var password = "123123";
        var empoloyees = Account.From(new RequestNewEmployee()
        {
            Email = "udv@mail.com", MiddleName = "Журавлёв", Name = "Vadim", Surname = "heruco"
        }, employeeRoleId, password);
        return empoloyees;
    }
    

    private async Task AddAndSetRole(string nameRole, IRoleRepository roles)
    {
        var role = await roles.Get(nameRole);
        if (role == null)
        {
            role = Role.From(nameRole);
            await roles.Add(role);
        }
    }
}