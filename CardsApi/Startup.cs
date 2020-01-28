using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesApi.Repository;
using NotesApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using CardsApi.Repository;

namespace NotesApi
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private readonly string DbConnectionString = "DefaultConnection";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);

            services.AddScoped<INotesRepository, NotesRepository>();
            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<NotesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(DbConnectionString)));
        }
    }
}
