using EduControl;
using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using EduControl.MiddleWare;
using Microsoft.AspNetCore.Mvc;
using PasswordGenerator;
using UdvBackend.Controllers.AdminController.Model;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Domen.Entities;
using UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;
using UdvBackend.Repositories;
using Task = UdvBackend.Domen.Entities.Task;

namespace UdvBackend.Controllers.AdminController;

[ApiController]
[Route("api/hr")]
public class HrController : ControllerBase
{
    private readonly IRoleRepository _roles;
    private readonly IAccountRepository _accounts;
    private readonly ILinkEmployeesHr _linkEmployeesHr;
    private readonly AccountScope _accountScope;
    public HrController(IRoleRepository roles, IAccountRepository accounts, ILinkEmployeesHr linkEmployeesHr, AccountScope accountScope)
    {
        _roles = roles;
        _accounts = accounts;
        _linkEmployeesHr = linkEmployeesHr;
        _accountScope = accountScope;
    }

    [HttpPost("create/hr")]
    public async Task<ApiResult<string>> Post([FromBody] RequestNewHr newHr)
    {
        var role = await _roles.Get(Roles.HR);
        if (role == null)
        {
            throw new Exception("роль не была создана при иницилазицаий базы данных");
        }


        var account = Account.From(newHr, role);
        await _accounts.Add(account);

        
        return "Account created"; //todo: а что выглядит неплохо, аха)(()
    }

    [HttpGet("my/employee")]
    public async Task<ApiResult<List<Account>>> Get()
    {
        var myEmployees = await _linkEmployeesHr.GetEmployees(_accountScope.Account.Id);

        return myEmployees;
    }
    
    [HttpPost("Create/employee")]
    public async Task<ApiResult<ResponseAccountEmployee>> Post([FromBody] RequestNewEmployee newAccount)
    {
        var role = await _roles.Get(Roles.Employee);
        if (role == null)
        {
            throw new Exception("роли не была создана при иницилазицаий базы данных");
        }

        var password = new Password().Next();
        var account = Account.From(newAccount, role, password);
        await _accounts.Add(account);

        var hrEmployees = HREmployees.From(_accountScope.Account, account);
        await _linkEmployeesHr.Connect(hrEmployees);
        
        return new ApiResult<ResponseAccountEmployee>(new ResponseAccountEmployee()
        {
            Email = account.Email,
            Password = password
        });
    }

    [HttpDelete("remove/employee/{id:guid}")]
    public async Task<ApiResult<string>> Delete(Guid id)
    {
        var myEmployees = await _linkEmployeesHr.GetEmployees(_accountScope.Account.Id);
        
        var employee = myEmployees.FirstOrDefault(x => x.Id == id);

        if (employee == null)
        {
            HttpContext.Response.StatusCode = 404;
            return new ApiResult<string>("Такого пользователя нету",
                string.Empty, 404);
        }

        await _accounts.Remove(employee);
        return "Пользователь удалён";
    }
}