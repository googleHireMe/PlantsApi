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
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class PlantStatesController : ControllerBase
	{
		private readonly IPlantsStateRepository plantsStateRepository;
		private readonly IUsersRepository usersRepository;
		private readonly UserManager<ApplicationUser> userManager;

		public PlantStatesController(IPlantsStateRepository plantsStateRepository,
									 IUsersRepository usersRepository,
									 UserManager<ApplicationUser> userManager)
		{
			this.userManager = userManager;
			this.plantsStateRepository = plantsStateRepository;
			this.usersRepository = usersRepository;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PlantState>> GetAsync(int id)
		{
			if (await HasAccessToPlantState(id))
				return plantsStateRepository.GetPlantState(id);
			else
				return NotFound();
		}

		[HttpGet]
		public async Task<IEnumerable<PlantState>> GetAsync()
		{
			var userGuid = (await userManager.GetUserAsync(User)).Id;
			var user = usersRepository.GetUser(userGuid, UserInclude.PlantStates);
			return user.PlantStates;
		}

		[HttpPost]
		public IActionResult Post([FromBody] PlantState value)
		{
			var created = plantsStateRepository.CreatePlantState(value);
			return CreatedAtAction(nameof(GetAsync), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] PlantState value)
		{
			if (id != value.Id) { return BadRequest(); }

			if (await HasAccessToPlantState(id))
			{
				plantsStateRepository.UpdatePlantState(value);
				return NoContent();
			}
			else
			{
				return NotFound();
			}

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			if (await HasAccessToPlantState(id))
			{
				plantsStateRepository.DeletePlantState(id);
				return NoContent();
			}
			else
			{
				return NotFound();
			}
		}

		private async Task<bool> HasAccessToPlantState(int plantStateId)
		{
			var userGuid = (await userManager.GetUserAsync(User)).Id;
			var userId = usersRepository.GetUser(userGuid).Id;
			var plantState = plantsStateRepository.GetPlantState(plantStateId);
			return plantState != null && plantState.UserId == userId;
		}



	}
}