using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using PlantsApi.Database;
using PlantsApi.Interfaces;
using PlantsApi.Models;
using PlantsApi.Repository;
using PlantsApi.Services.Initializers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PlantsApi
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private readonly string DbConnectionString = "PlantsConnection";
        private readonly string IdentityConnectionString = "IdentityConnection";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            ConfigureIdentity(services);
            ConfigureCors(services);
            ConfigureDependencies(services);
            var physicalProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            services.AddSingleton<IFileProvider>(physicalProvider);
            services.AddControllers()
                .AddNewtonsoftJson(o => {
                    o.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseDefaultFiles();
            try
            {
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles"))
                });
            }
            catch (Exception e)
            {

            }
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            services.AddScoped<IPlantsRepository, PlantsRepositiry>();
            services.AddScoped<IPlantsStateRepository, PlantsStateRepository>();
            services.AddScoped<IPlantAssigmentsRepository, PlantAssigmentsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddTransient<RuntimeInitializer, RuntimeInitializer>();
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<PlantsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(DbConnectionString)));

            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(IdentityConnectionString)));
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(10000);
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowCredentials()
                            .WithOrigins(
                            "http://localhost:1488",
                            "https://localhost:1488")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        //policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
        }
    }
}
