using EduControl;
using UdvBackend.Infrastructure.Result;

namespace UdvBackend.Infrastructure.Repositories.PlanetInfo;

public interface IPlanetInfoRepository
{
    public Task<Domen.Entities.PlanetInfo?> Get(Guid id);
    public Task<Domen.Entities.PlanetInfo[]> GetAll();
    public Task<Result<Domen.Entities.PlanetInfo, GetError>> Update(Domen.Entities.PlanetInfo planetInfo);
    public Task Create(Domen.Entities.PlanetInfo planetInfo);
}