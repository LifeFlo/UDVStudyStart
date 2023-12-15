using EduControl.DataBase.ModelBd;
using UdvBackend.Infrastructure.Extnentions;
using UdvBackend.Repositories;
using Vostok.Logging.Abstractions;

namespace EduControl.MiddleWare;

public class MiddleWareIsEmployee
{
    private static readonly ApiResult<Account>
        NotEmployee = new("auth:not-employee", string.Empty, 401);
    
    
    private readonly RequestDelegate _next;
    private readonly IRoleRepository _roles;
    private readonly ILog _log;
    
    public MiddleWareIsEmployee(IRoleRepository roles, ILog log, RequestDelegate next)
    {
        _roles = roles;
        _log = log;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AccountScope accountScope)
    {
        if (!accountScope.Account.IsEmployee())
        {
            await context.Response.WriteAsJsonAsync(NotEmployee);
            return;
        }

        await _next(context);
    }
}