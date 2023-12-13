using EduControl;
using EduControl.MiddleWare;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using UdvBackend.Controllers.NoteController.model;
using UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;
using UdvBackend.Infrastructure.Repositories.Note;
using Vostok.Logging.Abstractions;
using Task = UdvBackend.Domen.Entities.Task;

namespace UdvBackend.Controllers.NoteController;

[ApiController]
[Route("api/")]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _tasks;
    private readonly ILinkEmployeesHr _linkEmployeeHr;
    private readonly ILog _log;
    private readonly AccountScope _accountScope;

    public TaskController(ITaskRepository tasks, ILog log, AccountScope accountScope, ILinkEmployeesHr linkEmployeeHr)
    {
        _tasks = tasks;
        _log = log;
        _accountScope = accountScope;
        _linkEmployeeHr = linkEmployeeHr;
    }

    [HttpPost]
    [Route("hr/task/create")]
    public async Task<ApiResult<Task>> Post([FromBody] RequestTask requestTask)
    {
        var myEmployees = await _linkEmployeeHr.GetEmployees(_accountScope.Account.Id);
        _log.Info($"получены новички эйчара: {myEmployees}");
        if (myEmployees.Count == 0)
        {
            return new ApiResult<Task>("у тебя нету новичков", string.Empty, 200);
        }

        var employee = myEmployees.FirstOrDefault(x => x.Id == requestTask.userId);

        if (employee == null)
        {
            HttpContext.Response.StatusCode = 404;
            return new ApiResult<Task>("Такого пользователя нету",
                string.Empty, 404);
        }

        var task = Task.From(requestTask); // todo: можно сделать через implement

        await _tasks.Insert(task);

        return task;
    }

    [HttpGet]
    [Route("employee/tasks")]
    public async Task<ApiResult<List<Task>>> Get()
    {
        var tasks = await _tasks.Get(_accountScope.Account);

        return tasks;
    }

    [HttpPatch]
    [Route("employee/task/do")]
    public async Task<ApiResult<Task>> ChangeComplete([FromBody] RequestChangeCompleteTask requestChangeCompleteTask)
    {
        var task = await _tasks.Get(requestChangeCompleteTask.TaskId);
        if (task == null)
        {
            return new ApiResult<Task>("такой задачи нету", string.Empty, 404);
        }

        if (task.Id != _accountScope.Account.Id)
        {
            return new ApiResult<Task>("эта задача другого рабочего", string.Empty, 403);
        }

        var newTask = await _tasks.ChangeComplete(task, requestChangeCompleteTask.IsComplete);

        return newTask;
    }
}