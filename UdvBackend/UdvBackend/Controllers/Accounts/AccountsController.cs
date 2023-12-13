using EduControl;
using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using EduControl.MiddleWare;
using Microsoft.AspNetCore.Mvc;
using UdvBackend.DataBase.Entities.Account;
using UdvBackend.Repositories;

namespace UdvBackend.Controllers.Registered;

[ApiController]
[Route("api/account")]
public class AccountsController
{
    private readonly AccountScope _accountScope;
    public AccountsController(AccountScope accountScope)
    {
        _accountScope = accountScope;
    }
    
    [HttpGet]
    public async Task<ApiResult<ResponseAccountInfo>> Get()
    {
        return  (ResponseAccountInfo) _accountScope.Account;
    }
}