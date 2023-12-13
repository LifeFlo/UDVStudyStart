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

namespace UdvBackend.Controllers.AdminController;

[ApiController]
[Route("api/hr")]
public class AdminController
{
    private readonly IRoleRepository _roles;
    private readonly IAccountRepository _accounts;
    private readonly ILinkEmployeesHr _linkEmployeesHr;
    private readonly AccountScope _accountScope;
    public AdminController(IRoleRepository roles, IAccountRepository accounts, ILinkEmployeesHr linkEmployeesHr, AccountScope accountScope)
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
            throw new Exception("роли не была создана при иницилазицаий базы данных");
        }


        var account = Account.From(newHr, role);
        await _accounts.Add(account);

        
        return "Account created"; //todo: а что выглядит неплохо, аха)(()
    }


    [HttpPost("Create/employee")]
    public async Task<ApiResult<ResponseAccountEmployee>> PostEmployee([FromBody] RequestNewEmployee newAccount)
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
        _linkEmployeesHr.Connect(hrEmployees);
        
        return new ApiResult<ResponseAccountEmployee>(new ResponseAccountEmployee()
        {
            Name = account.Name,
            Password = password
        });
    }
}