using EduControl;
using Microsoft.AspNetCore.Mvc;
using UdvBackend.Controllers.Planets.Model;
using UdvBackend.Infrastructure.Repositories.PlanetHistory;
using Vostok.Logging.Abstractions;

namespace UdvBackend.Controllers.Planets;


[ApiController]
[Route("api/account")]
public class NovelController : ControllerBase
{
    private readonly IPlanetNovelRepository _planetNovelRepository;
    private readonly ILog _log;
    public NovelController(IPlanetNovelRepository planetNovelRepository, ILog log)
    {
        _planetNovelRepository = planetNovelRepository;
        _log = log;
    }

    [HttpGet("planet/{id:guid}/chapter/{chapter:int}")]
    public async Task<ApiResult<RequestChapterNovel>> Get(Guid id, int chapter)
    {
        var novel = await _planetNovelRepository.Get(id, chapter);
        if (novel == null)
        {
            _log.Warn($"Историй с этой главной нету {chapter}");
            HttpContext.Response.StatusCode = 404;
            return new ApiResult<RequestChapterNovel>("Такой части нету", "история с этой планетой уже закончена", 404);
        }

        return RequestChapterNovel.From(novel);
    }
}