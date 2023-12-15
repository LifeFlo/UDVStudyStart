using System.Net;
using EduControl;
using EduControl.MiddleWare;
using Microsoft.AspNetCore.Mvc;
using UdvBackend.Controllers.PlanetController.model;
using UdvBackend.Domen.Entities;
using UdvBackend.Infrastructure.Extnentions;
using UdvBackend.Infrastructure.Repositories.PlanetInfo;
using Vostok.Logging.Abstractions;

namespace UdvBackend.Controllers.PlanetController;

[ApiController]
[Route("api/")]
public class PlanetController : ControllerBase
{
    private readonly IPlanetInfoRepository _planetInfos;
    private readonly ILog _log;

    public PlanetController(IPlanetInfoRepository planetInfos, ILog log, AccountScope accountScope)
    {
        _planetInfos = planetInfos;
        _log = log;
    }

    [HttpGet("user/planets/info")]
    public async Task<ApiResult<List<PlanetInfo>>> GetAll()
    {
        var ids = await _planetInfos.GetAll();
        
        return ids;
    }

    [HttpGet("user/planets/info/{id:guid}")]
    public async Task<ApiResult<PlanetInfo>> Get(Guid id)
    {
        var planetInfo = await _planetInfos.Get(id);
        if (planetInfo == null)
        {
            _log.Warn($"info with guid:{id} not Found");
            return new ApiResult<PlanetInfo>("planetInfo not found", string.Empty, 404);
        }

        return planetInfo;
    }


    [HttpPut("hr/planets/info/Change")]
    public async Task<ApiResult<PlanetInfo>> Update([FromBody] PlanetInfo updatePlanetInfo)
    {
        var result = await _planetInfos.Update(updatePlanetInfo);
        if (result.HasError() || result.Value == null)
        {
            HttpContext.Response.StatusCode = 304;
            return result.ToApiResult(304);
        }

        return result.Value;
    }
}