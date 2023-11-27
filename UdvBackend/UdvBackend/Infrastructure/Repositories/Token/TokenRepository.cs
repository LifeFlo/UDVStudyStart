using EduControl.Controllers.Model;
using EduControl.DataBase;
using EduControl.DataBase.ModelBd;
using Microsoft.EntityFrameworkCore;
using UdvBackend.Infrastructure.Result;

namespace EduControl.Repositories;

public class TokenRepository : ITokenRepository
{
    private readonly UdvStartDb _db;

    public TokenRepository(UdvStartDb db)
    {
        _db = db;
    }

    public async Task Add(Token token)
    {
        await _db.Tokens.AddAsync(token);
        await _db.SaveChangesAsync();
    }

    public async Task<Result<Token, GetError>> Get(string token)
    {
        var tokenData = await _db.Tokens.FirstOrDefaultAsync(x => x.Value == token);
        return tokenData switch
        {
            null => new Result<Token, GetError>(GetError.Error, "Invalid token"),
            _ => new Result<Token, GetError>(tokenData)
        };
    }
}