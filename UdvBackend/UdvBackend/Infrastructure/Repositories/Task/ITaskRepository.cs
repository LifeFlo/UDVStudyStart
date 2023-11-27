using EduControl.DataBase.ModelBd;

namespace UdvBackend.Infrastructure.Repositories.Note;

public interface ITaskRepository
{
    public Task<Domen.Entities.Task?> Get(Guid id);
    public Task<List<Domen.Entities.Task>> Get(Account account);
    public Task Insert(Domen.Entities.Task task);
    public Task<Domen.Entities.Task> ChangeComplete(Domen.Entities.Task task, bool isComplete);
}