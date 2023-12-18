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
    public async Task<ApiResult<PlanetInfo[]>> GetAll()
    {
        var ids = await _planetInfos.GetAll();
        
        
        return ids;
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