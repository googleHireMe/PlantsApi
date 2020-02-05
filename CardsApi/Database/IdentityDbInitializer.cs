using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PlantsApi.Models;

namespace PlantsApi.Database
{
    public class IdentityDbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<IdentityDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    Email = "ali@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Ali"
                };
                userManager.CreateAsync(user, "Ali@123");
            }
        }
    }
}
