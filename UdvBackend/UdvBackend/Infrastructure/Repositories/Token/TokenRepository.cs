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

    public async Task Add(TokenInfo tokenInfo)
    {
        await _db.Tokens.AddAsync(tokenInfo);
        await _db.SaveChangesAsync();
    }

    public async Task<TokenInfo?> Get(string token)
    {
        var tokenData = await _db.Tokens.FirstOrDefaultAsync(x => x.Value == token);

        return tokenData;
    }
}