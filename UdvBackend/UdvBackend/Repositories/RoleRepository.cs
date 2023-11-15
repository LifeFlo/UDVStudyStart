using EduControl;
using EduControl.DataBase;
using EduControl.DataBase.ModelBd;
using Microsoft.EntityFrameworkCore;
using UdvBackend.DataBase.Entities.Account;
using Vostok.Logging.Abstractions;

namespace UdvBackend.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly UdvStartDb _db;
    private readonly ILog _log;

    public RoleRepository(UdvStartDb db, ILog log)
    {
        _db = db;
        _log = log;
    }


    public async Task Link(Role role, Guid accountId)
    {
        //todo: было бы круто сделать так, чтоб мы возращали резалт, ибо не понятно прошел ли запрос или нет)
        var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == accountId);

        if (account == null)
        {
            _log.Error($"account with id {accountId} not found");
            return;
        }

        account.RoleId = role.Id;
        await _db.SaveChangesAsync();
    }

    public async Task Add(Role role)
    {
        _db.Roles.Add(role);
        await _db.SaveChangesAsync();
    }

    public async Task<Role?> Get(string role)
    {
        return await _db.Roles.FirstOrDefaultAsync(x => x.Name == role);
    }

    public async Task<Role?> Get(Guid id)
    {
        return await _db.Roles.FirstOrDefaultAsync(x => x.Id == id);
    }
}