
using System.Runtime.InteropServices.JavaScript;
using EduControl;
using UdvBackend.Infrastructure.Result;

namespace UdvBackend.Infrastructure.Repositories.PlanetInfo;

public interface IPlanetInfoRepository
{
    public Task<Domen.Entities.PlanetInfo?> Get(Guid id);
    public Task<List<Domen.Entities.PlanetInfo>> GetAll();
    public Task<List<Guid>> GetAllId();
    public Task<Result<Domen.Entities.PlanetInfo, GetError>> Update(Domen.Entities.PlanetInfo planetInfo);
}