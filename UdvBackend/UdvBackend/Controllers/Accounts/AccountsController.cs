using EduControl;
using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using Microsoft.AspNetCore.Mvc;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Repositories;

namespace UdvBackend.Controllers.Registered;

[ApiController]
[Route("api/create/user")]
public class AccountsController
{
    private readonly IAccountRepository _accounts;
    private readonly IRoleRepository _roles;
    public AccountsController(IAccountRepository accounts, IRoleRepository roles)
    {
        _accounts = accounts;
        _roles = roles;
    }

    [HttpPost]
    public async Task<ApiResult<string>> Post([FromBody] RequestNewHr newHr)
    {
        var user = await _accounts.Get(newHr.Name);
        if (user.Value != null) return "username is busy";
        var role = await _roles.Get(Roles.Employee);
        if (role == null)
        {
            await _roles.Add(Role.From(Roles.Employee));
            role = await _roles.Get(Roles.Employee);
        }
                       
        
        var account = Account.From(newHr, role);
        await _accounts.Add(account);
        
        return "Account created"; //todo: а что выглядит неплохо, аха)(()
    }
}