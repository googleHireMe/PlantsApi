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
using PlantsApi.Models.DbModels;
using PlantsApi.Models.Enums;
using PlantsApi.Models.Dtos;
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
		private readonly IPlantsRepository plantsRepository;
		private readonly IAssigmentsRepository assigmentsRepository;
		private readonly IUsersRepository usersRepository;
		private readonly UserManager<ApplicationUser> userManager;

		public LinkController(IPlantsRepository plantsRepository,
							  IAssigmentsRepository assigmentsRepository,
							  IUsersRepository usersRepository,
							  UserManager<ApplicationUser> userManager)
		{
			this.plantsRepository = plantsRepository;
			this.assigmentsRepository = assigmentsRepository;
			this.usersRepository = usersRepository;
			this.userManager = userManager;
		}

		[Route("[action]")]
		[HttpGet]
		public async Task<IActionResult> GetDevices()
		{
			var user = await GetUserAsync();
			var devices = assigmentsRepository.GetUserDevices(user.Id);
            return Ok(devices);
        }

		[Route("[action]")]
		[HttpPost]
		public async Task<IActionResult> LinkDeviceToUser([FromBody] LinkUserToDeviceDto request)
		{
			var user = await GetUserAsync();
			assigmentsRepository.LinkDeviceToUser(user.Id, request.SerialNumber);
			return Ok();
		}

		[Route("[action]")]
		[HttpDelete]
		public async Task<IActionResult> UnlinkDeviceFromUser([FromBody] LinkUserToDeviceDto request)
		{
			var user = await GetUserAsync();
			var hasAccess = assigmentsRepository.HasUserAccessToDevice(user.Id, request.SerialNumber);
			if (hasAccess)
			{
				assigmentsRepository.UnlinkDeviceFromUser(user.Id, request.SerialNumber);
				return Ok();
			}
			return StatusCode(StatusCodes.Status403Forbidden, "User has no access to selected device");	
		}

		[Route("[action]")]
		[HttpPost]
		public async Task<IActionResult> LinkPlantToDevice([FromBody] LinkDeviceToPlantDto request)
		{
			var user = await GetUserAsync();
			var hasAccess = assigmentsRepository.HasUserAccessToDevice(user.Id, request.SerialNumber);
			if (hasAccess)
			{
				assigmentsRepository.LinkPlantToDevice(request.SerialNumber, request.PlantId);
				return Ok();
			}
			return StatusCode(StatusCodes.Status403Forbidden, "User has no access to selected device");
		}

		[Route("[action]")]
		[HttpDelete]
		public async Task<IActionResult> UnlinkPlantFromDevice([FromBody] LinkDeviceToPlantDto request)
		{
			var user = await GetUserAsync();
			var hasAccess = assigmentsRepository.HasUserAccessToDevice(user.Id, request.SerialNumber);
			if (hasAccess)
			{
				assigmentsRepository.UnlinkPlantFromDevice(request.SerialNumber);
				return Ok();
			}
			return StatusCode(StatusCodes.Status403Forbidden, "User has no access to selected device");
		}

		private async Task<User> GetUserAsync()
		{
			var userGuid = (await userManager.GetUserAsync(User)).Id;
			return usersRepository.GetUser(userGuid);
		}

	}
}