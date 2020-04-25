using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

		public DevicePlantController(IPlantsStateRepository plantsStateRepository,
									 IUsersRepository usersRepository,
									 UserManager<ApplicationUser> userManager,
									 SignInManager<ApplicationUser> signInManager)
		{
			this.userManager = userManager;
			this.plantsStateRepository = plantsStateRepository;
			this.usersRepository = usersRepository;
			this.signInManager = signInManager;
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

	}
}
