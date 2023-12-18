using EduControl;
using EduControl.DataBase;
using Microsoft.EntityFrameworkCore;
using UdvBackend.Infrastructure.Result;

namespace UdvBackend.Infrastructure.Repositories.PlanetInfo;

public class PlanetInfoRepository : IPlanetInfoRepository
{
    private readonly UdvStartDb _db;

    public PlanetInfoRepository(UdvStartDb db)
    {
        _db = db;
    }

    public async Task<Domen.Entities.PlanetInfo?> Get(Guid id)
    {
        return (await _db.PlanetInfos.FindAsync(id));
    }

    public async Task<Domen.Entities.PlanetInfo[]> GetAll()
    {
        return await _db.PlanetInfos.Where(x => true).ToArrayAsync();
    }


    //todo до реализовать запросы.
    public Task<Result<Domen.Entities.PlanetInfo, GetError>> Update(Domen.Entities.PlanetInfo planetInfo)
    {
        throw new NotImplementedException();
    }

    public async Task Create(Domen.Entities.PlanetInfo planetInfo)
    {
        await _db.AddAsync(planetInfo);
        await _db.SaveChangesAsync();
    }
    
    
}