using EduControl;
using EduControl.Controllers.Model;
using EduControl.MiddleWare;
using Microsoft.AspNetCore.Mvc;
using UdvBackend.Infrastructure.Extnentions;

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
    public ApiResult<ResponseAccountInfo> Get()
    {
        var role = _accountScope.Account.GetRole();
        if (role == null)
        {
            return new ApiResult<ResponseAccountInfo>("this account without role", "this account must be remove", 406);
        }

        return ResponseAccountInfo.From(_accountScope.Account, role);
    }
}