using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PlantsApi.Interfaces;
using PlantsApi.Models;
using PlantsApi.Models.Enums;
using PlantsApi.Models.ViewModels;
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DevicePlantController : ControllerBase
	{
		private readonly IPlantsStateRepository plantsStateRepository;
		private readonly IUsersRepository usersRepository;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly IFileProvider fileProvider;

		public DevicePlantController(IPlantsStateRepository plantsStateRepository,
									 IUsersRepository usersRepository,
									 UserManager<ApplicationUser> userManager,
									 SignInManager<ApplicationUser> signInManager,
									 IFileProvider fileProvider)
		{
			this.userManager = userManager;
			this.plantsStateRepository = plantsStateRepository;
			this.usersRepository = usersRepository;
			this.signInManager = signInManager;
			this.fileProvider = fileProvider;
		}

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DeviceInfoDto value)
        {
            var appUser = await userManager.FindByEmailAsync(value.UserEmail);
            if (appUser != null)
            {
                await signInManager.SignOutAsync();
                var signInResult = await signInManager
                    .PasswordSignInAsync(appUser, value.UserPassword, false, false);
                if (signInResult.Succeeded)
                {
                    var user = usersRepository.GetUser(appUser.Id);
                    var plantState = DeviceInfoDto.MapToPlantState(value, user.Id);
                    var created = plantsStateRepository.CreatePlantState(plantState);
                    return Ok();
                }
            }
            return Unauthorized();
        }

        [HttpGet]
		[Route("[action]")]
		public IActionResult GetFirmware()
		{
			var files = fileProvider.GetDirectoryContents(@"StaticFiles");
			var latestFile = files
				.ToList()
				.OrderByDescending(f => f.LastModified)
				.First();
			var fileNameWithExtension = latestFile.Name;
			var fileName = latestFile.Name.Split('.').First();
			var version = Convert.ToUInt64(fileName);

			var url = $"{this.Request.Scheme}://{this.Request.Host}/{fileNameWithExtension}";

			var response = new DeviceResponseDto()
			{
				Version = version,
				Link = url
			};
			return Ok(response);
		}

	}
}
