using EduControl.DataBase.ModelBd;
using UdvBackend.Controllers.NoteController.model;

namespace UdvBackend.Infrastructure.AccountService;

public interface IAccountService
{

    public Task<List<EmployeeInfo>> GetInfo(List<Account> accounts);
}