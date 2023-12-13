using EduControl;
using EduControl.DataBase.ModelBd;
using EduControl.MiddleWare;
using Microsoft.AspNetCore.Mvc.Filters;
using UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;
using Vostok.Logging.Abstractions;

namespace UdvBackend.Controllers.NoteController.ActionFilter;

public class CheckIsMyEmployee : ActionFilterAttribute
{
    private readonly ILinkEmployeesHr _linkEmployeesHr;
    private readonly ILog _log;
    private readonly AccountScope _accountScope;
    private static readonly ApiResult<object> NotHaveEmployee = new("у тебя нету новичков", string.Empty, 200);
    
    public CheckIsMyEmployee(ILinkEmployeesHr linkEmployeesHr, ILog log, AccountScope accountScope)
    {
        _linkEmployeesHr = linkEmployeesHr;
        _log = log;
        _accountScope = accountScope;
    }

    public override async void OnActionExecuting(ActionExecutingContext context)
    {
        var myEmployees = await _linkEmployeesHr.GetEmployees(_accountScope.Account.Id);
        _log.Info($"получены новички эйчара: {myEmployees}");
        if (myEmployees.Count == 0)
        {
            context.HttpContext.Response.StatusCode = 200;
            await context.HttpContext.Response.WriteAsJsonAsync(NotHaveEmployee);
            return ;
        }
        
        base.OnActionExecuting(context);
    }
}