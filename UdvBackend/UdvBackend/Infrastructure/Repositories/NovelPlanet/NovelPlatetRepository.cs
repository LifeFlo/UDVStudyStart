using System.Runtime.CompilerServices;
using EduControl.DataBase;
using Microsoft.EntityFrameworkCore;
using UdvBackend.Domen.Entities;
using Task = System.Threading.Tasks.Task;

namespace UdvBackend.Infrastructure.Repositories.PlanetHistory;

public class NovelPlanetRepository : INovelPlanetRepository
{
    private readonly UdvStartDb _db;

    public NovelPlanetRepository(UdvStartDb db)
    {
        _db = db;
    }

    public Task<Novel?> Get(Guid planetId, int chapter)
    {
        return _db.Novels.FirstOrDefaultAsync(x => x.IdPlanetInfo == planetId && x.Chapter == chapter);
    }

    public async Task Add(Novel novelChapter)
    {
        await _db.AddAsync(novelChapter);
        await _db.SaveChangesAsync();
    }
}