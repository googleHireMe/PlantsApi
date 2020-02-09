using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PlantsApi.Database;
using PlantsApi.Models;

namespace PlantsApi
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var serviceProvider = scope.ServiceProvider;
				try
				{
					var plantsContext = serviceProvider.GetRequiredService<PlantsContext>();
					PlantsDbInitializer.Initialize(plantsContext);

					var identityContext = serviceProvider.GetRequiredService<IdentityContext>();
					var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
					await IdentityDbInitializer.InitializeAsync(identityContext, userManager);
				}
				catch (Exception ex)
				{
					var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while seeding the database.");
				}
			}

			host.Run();
		}

		public static IHostBuilder CreateWebHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
