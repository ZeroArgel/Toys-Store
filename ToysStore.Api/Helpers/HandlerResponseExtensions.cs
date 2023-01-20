namespace ToysStore.Api.Helpers
{
    using Microsoft.AspNetCore.Builder;

    /// <summary>
    /// 
    /// </summary>
    public static class HandlerResponseExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHandlerResponse(this IApplicationBuilder app)
        {
            app.UseRouting();
            return app.UseMiddleware<HandlerResponse>();
        }
    }
}