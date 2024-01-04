using EduControl.DataBase;
using EduControl.DataBase.ModelBd;
using EduControl.MiddleWare;
using Microsoft.EntityFrameworkCore;
using Vostok.Logging.Abstractions;
using Task = UdvBackend.Domen.Entities.Task;

namespace UdvBackend.Infrastructure.Repositories.Note;

public class TaskRepository : ITaskRepository
{
    private readonly UdvStartDb _db;
    private readonly ILog _log;
    public TaskRepository(UdvStartDb db, ILog log)
    {
        _db = db;
        _log = log;
    }
    
    public async Task<Task?> Get(Guid id)
    {
        return await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Task>> GetAllByAccount(Guid idAccount)
    {
        var tasks = await _db.Tasks.Where(x => x.AccountId == idAccount).ToListAsync();
        return tasks;
    }
    
    public async System.Threading.Tasks.Task Insert(Task task)
    {
        await _db.Tasks.AddAsync(task);
        await _db.SaveChangesAsync();
    }

    public async Task<Task> ChangeComplete(Task task) // сделать с возвращением result
    {
        var taskBd = await _db.Tasks.FindAsync(task.Id);
        if (taskBd == null)
        {
            _log.Warn($"задачи с id: {task.Id} не существует");
            return null ;
        }
        
        taskBd.IsComplete = !task.IsComplete;
        await _db.SaveChangesAsync();
        return taskBd;
    }
}