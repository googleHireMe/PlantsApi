using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlantsApi.Models;

namespace PlantsApi.Database
{
    public class IdentityDbInitializer
    {
        public static async Task InitializeAsync(IdentityContext context, UserManager<ApplicationUser> userManager)
        {
            const string password = "Sectret@228";
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            //context.Database.Migrate();
            if (!context.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    Email = "nanevokshonov@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "nanevokshonov"
                };
                var result = await userManager.CreateAsync(user, password);
                //context.SaveChanges();
            }
        }
    }
}
