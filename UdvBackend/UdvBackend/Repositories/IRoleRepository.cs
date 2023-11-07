using EduControl.DataBase.ModelBd;
using UdvBackend.DataBase.Entities.Account;

namespace UdvBackend.Repositories;

public interface IRoleRepository
{
    public Task Link(string role, Account account);
    public Task Add(Role role);
    public Task<Role?> Get(string role);
}