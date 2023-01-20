namespace ToysStore.Api
{
    #region usings.
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Helpers;
    using DataAccess.Core;
    using DataAccess.Interfaces;
    using ZAExtensions.zCore;
    #endregion
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        private const string HandleName = "ToysStore.Handlers";
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="configuration"></param>
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // implement MediatR.
            services.AddMediatR(HandleName.GetMediatRConfig());

            // implement Swagger.
            services.AddSwaggerNet(_environment);

            services.AddScoped<IServicesCompanies, ServicesCompanies>();
            services.AddScoped<IServicesProducts, ServicesProducts>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(ServicesBase<>));
            services.AddScoped(typeof(ToysStoreContext));

            // Http cookies and auth
            services.AddHttpContextAccessor();
            //services.AddScoped<IZTokens<Guid, Guid>, ZTokens<Guid, Guid>>();
            // Authentication.
            services.AddAuthentication(za => {
                za.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                za.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(za => {
                za.Cookie.Name = _configuration["ZToken"];
                za.Cookie.HttpOnly = false;
                za.Cookie.SameSite = SameSiteMode.Unspecified;
            });

            services.AddControllersWithViews()
                .AddJsonOptions(json =>
                {
                    json.JsonSerializerOptions.WriteIndented = true;
                })
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerNet();
                app.UseCors(options =>
                    options.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                );
            }
            app.UseHandlerResponse();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}