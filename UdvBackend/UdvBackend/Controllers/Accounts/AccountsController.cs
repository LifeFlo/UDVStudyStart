using EduControl;
using EduControl.Controllers.Model;
using EduControl.MiddleWare;
using Microsoft.AspNetCore.Mvc;
using UdvBackend.Infrastructure.Extnentions;
using UdvBackend.Repositories;

namespace UdvBackend.Controllers.Registered;

[ApiController]
[Route("api/account")]
public class AccountsController
{
    private readonly AccountScope _accountScope;
    public AccountsController(
        AccountScope accountScope,
        IRoleRepository roleRepository)
    {
        _accountScope = accountScope;
    }

    [HttpGet]
    public async Task<ApiResult<AccountInfo>> Get()
    {
        return _accountScope.Account;
    }
}