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
    public async Task<ApiResult<string>> Post([FromBody] RequestNewAccount newAccount)
    {
        var user = await _accounts.Get(newAccount.Name);
        if (user.Value != null) return "username is busy";
        var role = await _roles.Get(Roles.User);
        if (role == null)
        {
            await _roles.Add(Role.From(Roles.User));
            role = await _roles.Get(Roles.User);
        }
                       
        
        var account = Account.From(newAccount, role);
        await _accounts.Add(account);
        
        return "Account created"; //todo: а что выглядит неплохо, аха)(()
    }
}