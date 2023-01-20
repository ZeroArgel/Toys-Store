using Microsoft.Extensions.Primitives;

namespace ToysStore.Api.Helpers
{
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Models.Filters;
    using Microsoft.AspNetCore.Http;
    using ZAExtensions.zCore;
    /// <summary>
    /// 
    /// </summary>
    public class HandlerResponse
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public HandlerResponse(RequestDelegate next) => _next = next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            try
            {
                // Get current culture or languages.
                if (!httpContext.Request.Headers.TryGetValue("CultureInfo", out var cultureInfo))
                    cultureInfo = "en-US";

                // Get current zoneId
                if (!httpContext.Request.Headers.TryGetValue("ZoneId", out var zoneId))
                    zoneId = "Central Standard Time";

                httpContext.Features.Set<IHeadersRequest>(new HeadersRequest(cultureInfo, zoneId));
                await _next.Invoke(httpContext);
            }
            catch (ZException ex)
            {
                httpContext.Response.StatusCode = ex.StatusCode;

                var response = ex.Message.ZCustom(
                    httpContext.Response.StatusCode,
                    false,
                    ex.DataResponse,
                    ex.MessageDetails);
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (Exception ex)
            {
                var response = ex.Message.ZBad<string>(messageDetails: ex.InnerException?.Message.Split(". "));
                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}