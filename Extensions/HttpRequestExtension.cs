using simo2api.Models;
using Microsoft.AspNetCore.Http;

namespace simo2api.Extensions
{
    public static class HttpRequestExtension
    {


        public static WhoAmI GetHeader(this HttpRequest request)
        {
            return new WhoAmI
            {
                IpAddress = request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                UserAgent = request.Headers["User-Agent"].ToString(),
                UserLanguages = request.Headers["Accept-Language"].ToString(),
                xUserID = request.Headers["x-UserID"].ToString()
            };
        }
    }
}