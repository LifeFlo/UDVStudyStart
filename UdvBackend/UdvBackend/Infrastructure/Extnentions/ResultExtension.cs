using EduControl;
using UdvBackend.Infrastructure.Result;

namespace UdvBackend.Infrastructure.Extnentions;

public static class ResultExtension
{
    public static ApiResult<T> ToApiResult<T>(this Result<T, GetError> result, int statusCode)
    {
         return new ApiResult<T>(result.Error.ToString(), result.ErrorExplain, statusCode);
    }
}