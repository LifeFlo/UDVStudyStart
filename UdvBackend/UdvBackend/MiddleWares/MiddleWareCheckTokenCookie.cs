using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using EduControl.Repositories;
using UdvBackend.Infrastructure.Result;
using UdvBackend.Repositories;
using Vostok.Logging.Abstractions;

namespace EduControl.MiddleWare;

public class MiddleWareCheckTokenCookie
{
    private static readonly ApiResult<Account>
        AccountNotFound = new("auth:cookie-is-empty", "try authorization", 403);

    private static readonly ApiResult<Account> TokenNotLinkAccount =
        new("auth:token-not-link-account", "you have token, but it haven't account", 403);
    private readonly RequestDelegate _next;
    private readonly ILog _log;
    private readonly IAccountRepository _accounts;
    private readonly ITokenRepository _tokens;
    
    public MiddleWareCheckTokenCookie(RequestDelegate next, ILog log, IAccountRepository accounts, ITokenRepository tokens, IRoleRepository roleRepository)
    {
        _next = next;
        _log = log;
        _accounts = accounts;
        _tokens = tokens;
    }

    public async Task InvokeAsync(HttpContext context, AccountScope accountScope)
    {
        if (!context.Request.Cookies.TryGetValue("token", out var token) || string.IsNullOrEmpty(token))
        {
            await context.Response.WriteAsJsonAsync(AccountNotFound);
            return;
        }
        
        _log.Info($"token here: {token}");
        var tokenResponse = await _tokens.Get(token);
        if (tokenResponse == null)
        {
            _log.Warn($"token {token} haven't account");
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(TokenNotLinkAccount);
            return;
        }
        
        var tokenData = tokenResponse.Value;
        
        var accountResponse = await _accounts.Get(tokenData);
        if (accountResponse == null)
        {
            _log.Warn($"Account With token{token} Not Found");
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(accountResponse);
            return;
        }

        accountScope.Account = accountResponse;
        await _next(context);
    }
}