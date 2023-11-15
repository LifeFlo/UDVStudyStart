using EduControl;
using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using Microsoft.AspNetCore.Mvc;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Repositories;

namespace UdvBackend.Controllers.AdminController;

[ApiController]
[Route("api/admin")]
public class AdminController
{
    private readonly IRoleRepository _roles;
    private readonly IAccountRepository _accounts;

    public AdminController(IRoleRepository roles, IAccountRepository accounts)
    {
        _roles = roles;
        _accounts = accounts;
    }
    
    [HttpPost("create/admin")]
    public async Task<ApiResult<string>> Post([FromBody] RequestNewAccount newAccount)
    {
        var user = await _accounts.Get(newAccount.Name);
        if (user.Value != null) return "username is busy";
        var role = await _roles.Get(Roles.Admin);
        if (role == null)
        {
            await _roles.Add(Role.From(Roles.Admin));
            role = await _roles.Get(Roles.Admin);
        }
                       
        
        var account = Account.From(newAccount, role);
        await _accounts.Add(account);
        
        return "Account created"; //todo: а что выглядит неплохо, аха)(()
    }
    
}