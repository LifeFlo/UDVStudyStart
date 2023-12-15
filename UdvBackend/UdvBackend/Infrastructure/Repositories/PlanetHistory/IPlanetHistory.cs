using UdvBackend.Domen.Entities;

namespace UdvBackend.Infrastructure.Repositories.PlanetHistory;

public interface IPlanetNovelRepository
{
    Task<Novel?>  Get(Guid id, int chapter);
}