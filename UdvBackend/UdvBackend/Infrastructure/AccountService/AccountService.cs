using EduControl.DataBase.ModelBd;
using UdvBackend.Controllers.NoteController.model;
using UdvBackend.Infrastructure.Repositories.Note;

namespace UdvBackend.Infrastructure.AccountService;

public class AccountService : IAccountService
{

    public readonly ITaskRepository _tasks;

    public AccountService(ITaskRepository tasks)
    {
        _tasks = tasks;
    }

    public async Task<List<EmployeeInfo>> GetInfo(List<Account> accounts)
    {
        var result = new List<EmployeeInfo>();
        foreach (var myEmployee in accounts)
        {
            var tasks = await _tasks.Get(myEmployee);
            var completeTask = tasks.Where(x => x.IsComplete).ToArray();

            result.Add(EmployeeInfo.From(myEmployee, completeTask.Length, tasks.Count));
        }

        return result;
    }
}