using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using UdvBackend.Infrastructure.Result;

namespace EduControl.Repositories;

public interface ITokenRepository
{
    public  Task Add(TokenInfo tokenInfo);

    public Task<TokenInfo?> Get(string token);
}