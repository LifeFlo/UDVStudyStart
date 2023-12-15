using EduControl;
using EduControl.Controllers.Model;
using EduControl.DataBase;
using EduControl.DataBase.ModelBd;
using Microsoft.EntityFrameworkCore;
using UdvBackend.Infrastructure.Result;
using Vostok.Logging.Abstractions;

namespace UdvBackend.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly UdvStartDb _db;
    private readonly ILog _log;
    public AccountRepository(UdvStartDb db, ILog log)
    {
        _db = db;
        _log = log;
    }

    public async Task<Account?> Get(TokenInfo tokenInfo)
    {
        try
        {
            var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == tokenInfo.UsedId);
            
            return account;
        }
        catch (Exception e)
        {
            _log.Error($"Occured Error while work database: {e}");
            return null;
        }
    }

    public async Task<Account?> Get(string email)
    {
        var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Email == email);
        
        return account;
    }

    public async Task Remove(Account account)
    {
        _db.Accounts.Remove(account);
        await _db.SaveChangesAsync();
    }


    public async Task Add(Account account)
    {
        await _db.Accounts.AddAsync(account);
        await _db.SaveChangesAsync();
    }
}