using EduControl.DataBase.ModelBd;
using UdvBackend.Domen.Entities;
using Task = System.Threading.Tasks.Task;

namespace UdvBackend.Infrastructure.Repositories.ILinkEmployeesHR;

public interface ILinkEmployeesHr
{
    public Task<List<Account>> GetEmployees(Guid hrId);
    public Task Connect(HREmployees hrEmployees);
}