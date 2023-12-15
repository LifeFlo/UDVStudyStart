using EduControl.Repositories;
using UdvBackend.Repositories;
using Vostok.Logging.Abstractions;

namespace EduControl.MiddleWare;

public class MIddleWareCheckTokenHeader
{
    
    private static readonly ApiResult<object> AccessTokenNotPresentError = new("auth:access-token-not-present", "insert an access_token as bearer in 'Authorization' header", 403);
    private static readonly ApiResult<string> AccessTokenLooksNotABearerError = new("auth:access-token-is-not-bearer", "Authorization header should have format: 'bearer <your token here>'", 403);
    private static readonly ApiResult<object> AccessTokenInvalidError = new("auth:access-token-invalid", "get new access token", 403);
    private static readonly ApiResult<object> TokenNotLinkAccount = new("auth:token-not-link-account", "you have token, but it haven't account", 403);
    private static readonly string AuthorizationHeaderPrefix = "bearer";

    private readonly RequestDelegate next;
    private readonly IAccountRepository _accounts;
    private readonly ITokenRepository _tokens;
    private readonly ILog log;

    public MIddleWareCheckTokenHeader(RequestDelegate next, ILog log, ITokenRepository tokens, IAccountRepository accounts)
    {
        this.next = next;
        _tokens = tokens;
        _accounts = accounts;
        this.log = log.ForContext("AccessTokenMiddleware");
    }

    public async Task InvokeAsync(HttpContext context, AccountScope accountScope)
    {
        if (!context.Request.Headers.TryGetValue("Authorization", out var authorization) || authorization.Count == 0)
        {
            log.Warn("tried to access api without an access token");
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(AccessTokenNotPresentError);
            return;
        }

        var bearer = authorization[0];
        if (bearer.IndexOf(AuthorizationHeaderPrefix, StringComparison.InvariantCultureIgnoreCase) != 0)
        {
            log.Warn("tried to access api with malformed token");
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(AccessTokenLooksNotABearerError);
            return;
        }

        var token = bearer.AsSpan()
            .Slice(AuthorizationHeaderPrefix.Length)
            .Trim(' ')
            .ToString();

        var accessToken = await _tokens.Get(token);
        
        if (accessToken == null || accessToken.CreateDt + accessToken.Ttl < DateTime.UtcNow)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(AccessTokenInvalidError);
            return;
        }

        var account = await _accounts.Get(accessToken.Value);

        if (account == null)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(TokenNotLinkAccount);
            return;
        }

        accountScope.Account = account;
        await next(context);
    }

}