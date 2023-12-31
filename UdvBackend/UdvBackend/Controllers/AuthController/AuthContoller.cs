using System;
using System.Threading.Tasks;
using EduControl.Controllers.Model;
using EduControl.Repositories;
using EduControl.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UdvBackend.Repositories;
using Vostok.Logging.Abstractions;

namespace EduControl.Controllers;

[ApiController]
[Route("api/Auth")]
public class AuthController: ControllerBase
{
    private readonly ILog _log;
    private readonly IAccountRepository _accounts;
    private readonly ITokenRepository _tokens;

    public AuthController(ILog log, IAccountRepository accounts, ITokenRepository tokens)
    {
        _log = log;
        _accounts = accounts;
        _tokens = tokens;
    }

    [HttpPost]
    public async Task<ApiResult<string>> Post(RequestGetToken requestUser)
    {
        var response = await _accounts.Get(requestUser.Email);
        if (response.HasError() || response.Value == null)
        {
            return new ApiResult<string>(response.Error.ToString(), response.ErrorExplain, 403);
        }
        
        var account = response.Value;
        if (Hasher.VerifyPassword(account ,requestUser.Password) == PasswordVerificationResult.Failed)
        {
            _log.Info($"user: {account.Name} write wrong password");
            return new ApiResult<string>("Wrong password", string.Empty, 403);
        }
        
        var token = Token.From(GenerateCode.GenerateToken(), account);
        
        await _tokens.Add(token);
        HttpContext.Response.Cookies.Append("token", token.Value);
        return "Token Received";
    } 
}