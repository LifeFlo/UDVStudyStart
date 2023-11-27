using EduControl.DataBase;
using EduControl.DataBase.ModelBd;
using Microsoft.EntityFrameworkCore;
using Task = UdvBackend.Domen.Entities.Task;

namespace UdvBackend.Infrastructure.Repositories.Note;

public class TaskRepository : ITaskRepository
{
    private readonly UdvStartDb _db;

    public TaskRepository(UdvStartDb db)
    {
        _db = db;
    }
    
    public Task<Task?> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Task>> Get(Account account)
    {
        var tasks = await _db.Tasks.Where(x => x.UserId == account.Id).ToListAsync();
        return tasks;
    }

    public async System.Threading.Tasks.Task Insert(Task task)
    {
        await _db.Tasks.AddAsync(task);
        await _db.SaveChangesAsync();
    }

    public Task<Task> ChangeComplete(Task task, bool isComplete)
    {
        throw new NotImplementedException();
    }
}