using EduControl.Controllers.Model;
using EduControl.DataBase.ModelBd;
using UdvBackend.Infrastructure.Result;

namespace EduControl.Repositories;

public interface ITokenRepository
{
    public  Task Add(Token token);

    public Task<Result<Token, GetError>> Get(string token);
}