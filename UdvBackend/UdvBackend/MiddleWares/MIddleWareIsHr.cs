using EduControl.DataBase.ModelBd;
using UdvBackend;
using UdvBackend.Infrastructure.Extnentions;
using UdvBackend.Repositories;
using Vostok.Logging.Abstractions;

namespace EduControl.MiddleWare;

public class MiddleWareIsHr
{
    private static readonly ApiResult<Account>
        NotAdmin = new("auth:not-admin", string.Empty, 401);
    
    
    private readonly RequestDelegate _next;
    private readonly ILog _log;
    
    public MiddleWareIsHr( ILog log, RequestDelegate next)
    {
        _log = log;
        _next = next;
        _log.ForContext("MiddleWareIsAdmin");
    }

    public async Task InvokeAsync(HttpContext context, AccountScope accountScope)
    {
        if (!accountScope.Account.IsHr())
        {
            _log.Info("try Use command without permission");
            await context.Response.WriteAsJsonAsync(NotAdmin);
            return;
        }

        await _next(context);
    }
}