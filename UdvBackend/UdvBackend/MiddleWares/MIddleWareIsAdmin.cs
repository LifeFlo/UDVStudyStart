using EduControl.DataBase.ModelBd;
using UdvBackend.Infrastructure.Extnentions;
using UdvBackend.Repositories;
using Vostok.Logging.Abstractions;

namespace EduControl.MiddleWare;

public class MiddleWareIsAdmin
{
    private static readonly ApiResult<Account>
        NotAdmin = new("auth:not-admin", string.Empty, 401);
    
    
    private readonly RequestDelegate _next;
    private readonly IRoleRepository _roles;
    private readonly ILog _log;
    
    public MiddleWareIsAdmin(IRoleRepository roles, ILog log, RequestDelegate next)
    {
        _roles = roles;
        _log = log;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AccountScope accountScope)
    {
        _log.Info("run middleWareIsAdmin");
        var role = await _roles.Get(accountScope.Account.RoleId);
        if (!role.IsAdmin())
        {
            await context.Response.WriteAsJsonAsync(NotAdmin);
            return;
        }

        await _next(context);
    }
}