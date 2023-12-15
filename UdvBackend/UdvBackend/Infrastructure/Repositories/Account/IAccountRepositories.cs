using EduControl;
using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using UdvBackend.Infrastructure.Result;

namespace UdvBackend.Repositories;

public interface IAccountRepository
{
    public Task<Account?> Get(TokenInfo tokenInfo);

    public Task<Account?> Get(string email);

    public Task Remove(Account account);

    public Task Add(Account account);
}