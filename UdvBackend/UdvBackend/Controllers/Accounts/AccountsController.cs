using EduControl;
using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using Microsoft.AspNetCore.Mvc;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Repositories;

namespace UdvBackend.Controllers.Registered;

[ApiController]
public class AccountsController
{
    private readonly IAccountRepository _accounts;
    private readonly IRoleRepository _roles; //todo: make
    public AccountsController(IAccountRepository accounts, IRoleRepository roles)
    {
        _accounts = accounts;
        _roles = roles;
    }

    [HttpPost]
    public async Task<ApiResult<string>> Post([FromBody] RequestNewAccount newAccount) //todo: make connect with Role
    {
        var user = await _accounts.Get(newAccount.UserName);
        if (user.Value != null) return "username is busy";
        var role = await _roles.Get(newAccount.Role);
        if (role == null)
        {
            await _roles.Add(Role.From(newAccount.Role));
            role = await _roles.Get(newAccount.Role);
        }
                       
        
        var account = Account.From(newAccount, role);
        await _accounts.Add(account); //todo maybe code is becoming harder for read?
        
        return "Account created"; //todo: а что выглядит неплохо, аха)(()
    }
}