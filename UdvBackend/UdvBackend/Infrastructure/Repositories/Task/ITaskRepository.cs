using EduControl.DataBase.ModelBd;

namespace UdvBackend.Infrastructure.Repositories.Note;

public interface ITaskRepository
{
    public Task<Domen.Entities.Task?> Get(Guid taskId);
    public Task<List<Domen.Entities.Task>> Get(Account account); // todo: по идей здесь явно не должен быть лист, ибо мы и не должны его как-то менять)
    public Task Insert(Domen.Entities.Task task);
    public Task<Domen.Entities.Task> ChangeComplete(Domen.Entities.Task task);
}