namespace ToysStore.Api.Helpers
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Linq;
    using System.Reflection;
    using Swashbuckle.AspNetCore.SwaggerUI;
    using ZAExtensions.zCore;
    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerExtension
    {
        private const string Title = "Toys Store Api";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="env"></param>
        public static void AddSwaggerNet(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Assembly.GetExecutingAssembly().GetXmlPathSwagger(env.IsDevelopment(), "net5.0"));
                c.EnableAnnotations();
                c.IgnoreObsoleteActions();
                c.CustomSchemaIds(s => s.FullName?.Replace("+", "."));
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddSwaggerGenNewtonsoftSupport(); // Support for newtonsoft to swagger
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerNet(this IApplicationBuilder app)
        {
            app.UseSwagger(s => s.SerializeAsV2 = true);
            app.UseSwaggerUI(su =>
            {
                su.SwaggerEndpoint($"/swagger/v1/swagger.json", $"{Title} v1");
                su.DocumentTitle = $"{Title}";
                su.RoutePrefix = "swagger";
                su.DisplayRequestDuration();
                su.DefaultModelsExpandDepth(-1);
                su.DocExpansion(DocExpansion.None);
            });
        }
    }
}