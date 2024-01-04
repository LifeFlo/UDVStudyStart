using EduControl;
using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using EduControl.MiddleWare;
using Microsoft.AspNetCore.Mvc;
using PasswordGenerator;
using UdvBackend.Controllers.AdminController.Model;
using UdvBackend.Controllers.NoteController.model;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Domen.Entities;
using UdvBackend.Infrastructure.AccountService;
using UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;
using UdvBackend.Infrastructure.Repositories.Note;
using UdvBackend.Repositories;
using Vostok.Logging.Abstractions;
using Task = UdvBackend.Domen.Entities.Task;

namespace UdvBackend.Controllers.AdminController;

[ApiController]
[Route("api/hr")]
public class HrController : ControllerBase
{
    private readonly IAccountRepository _accounts;
    private readonly ILinkEmployeesHr _linkEmployeesHr;
    private readonly AccountScope _accountScope;
    private readonly IAccountService _accountService;
    private readonly ILog _log;
    private readonly IRoleRepository _roles;

    public HrController(IRoleRepository roles,
        IAccountRepository accounts,
        ILinkEmployeesHr linkEmployeesHr,
        AccountScope accountScope,
        IAccountService accountService,
        ILog log)
    {
        _roles = roles;
        _accounts = accounts;
        _linkEmployeesHr = linkEmployeesHr;
        _accountScope = accountScope;
        _accountService = accountService;
        _log = log;
    }

    [HttpPost("create/hr")]
    public async Task<ApiResult<string>> Post([FromBody] RequestNewHr newHr)
    {
        var role = await _roles.Get(Roles.Hr);
        if (role == null)
        {
            _log.Warn("нету роли Hr В бд");
            return "Роли HR нету в базе данных";
        }
        
        var account = Account.From(newHr, role.Id);
        await _accounts.Add(account);

        return "Account created"; //todo: а что выглядит неплохо, аха)(()
    }

    [HttpGet("my/employee")]
    public async Task<ApiResult<List<EmployeeInfo>>> Get()
    {
        var myEmployees = await _linkEmployeesHr.GetEmployees(_accountScope.Account.Id);

        _log.Info($"получены новички эйчара: {myEmployees}");
        if (myEmployees.Count == 0)
        {
            return new ApiResult<List<EmployeeInfo>>("у тебя нету новичков", string.Empty, 200);
        }


        var result = await _accountService.GetInfo(myEmployees);

        return result;
    }

    [HttpPost("Create/employee")]
    public async Task<ApiResult<ResponseAccountEmployeeAfterCreated>> Post([FromBody] RequestNewEmployee newAccount)
    {
        var role = await _roles.Get(Roles.Employee);
        if (role == null)
        {
            _log.Warn("нету роли работника В бд");
            return new ApiResult<ResponseAccountEmployeeAfterCreated>("роли Employee нету", string.Empty, 500); // по идей здесь я бэк должен перезапускаться 
        }
        
        
        var password = new Password().Next();
        var account = Account.From(newAccount, role.Id, password);
        await _accounts.Add(account);

        var hrEmployees = HREmployees.From(_accountScope.Account.Id, account.Id);
        await _linkEmployeesHr.Connect(hrEmployees);

        return new ApiResult<ResponseAccountEmployeeAfterCreated>(new ResponseAccountEmployeeAfterCreated()
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