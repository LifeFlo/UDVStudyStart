using EduControl;
using EduControl.Controllers.Model;
using EduControl.DataBase;
using EduControl.DataBase.ModelBd;
using Microsoft.EntityFrameworkCore;
using UdvBackend.Infrastructure.Result;

namespace UdvBackend.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly UdvStartDb _db;

    public AccountRepository(UdvStartDb db)
    {
        _db = db;
    }

    public async Task<Result<Account, GetError>> Get(TokenInfo tokenInfo)
    {
        try
        {
            var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == tokenInfo.UsedId);
            return account switch
            {
                null => new Result<Account, GetError>(GetError.NotFound, "Account not found"),
                _ => new Result<Account, GetError>(account)
            };
        }
        catch (Exception e)
        {
            return new Result<Account, GetError>(GetError.Error, e.Message);
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