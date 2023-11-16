using EduControl.DataBase.ModelBd;
using UdvBackend.DataBase.Entities.Account;

namespace UdvBackend.Repositories;

public interface IRoleRepository
{
    public Task Link(Role role, Guid account);
    public Task Add(Role role);
    public Task<Role?> Get(string role);
    public Task<Role?> Get(Guid id);
}