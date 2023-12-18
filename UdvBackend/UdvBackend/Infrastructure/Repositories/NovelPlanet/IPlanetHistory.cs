using UdvBackend.Domen.Entities;
using Task = System.Threading.Tasks.Task;

namespace UdvBackend.Infrastructure.Repositories.PlanetHistory;

public interface INovelPlanetRepository
{
    Task<Novel?>  Get(Guid planetId, int chapter);
    Task Add(Novel novelChapter);
}