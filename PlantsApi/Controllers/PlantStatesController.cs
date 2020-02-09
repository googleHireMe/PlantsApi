using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlantsApi.Models;
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class PlantStatesController : ControllerBase
	{
		private readonly IPlantsRepository repository;
		private readonly UserManager<ApplicationUser> userManager;

		public PlantStatesController(IPlantsRepository repository,
								UserManager<ApplicationUser> userManager)
		{
			this.repository = repository;
			this.userManager = userManager;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PlantState>> GetAsync(int id)
		{
			if (await HasAccessToPlantState(id))
				return repository.GetPlantState(id);
			else
				return NotFound();
		}

		[HttpGet]
		public async Task<IEnumerable<PlantState>> GetAsync()
		{
			var userGuid = (await userManager.GetUserAsync(User)).Id;
			var user = repository.GetUser(userGuid);
			return user.PlantStates;
		}

		[HttpPost]
		public IActionResult Post([FromBody] PlantState value)
		{
			var created = repository.CreatePlantState(value);
			return CreatedAtAction(nameof(GetAsync), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] PlantState value)
		{
			if (id != value.Id) { return BadRequest(); }

			if (await HasAccessToPlantState(id))
			{
				repository.UpdatePlantState(value);
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
				repository.DeletePlant(id);
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
			var userId = repository.GetUser(userGuid).Id;
			var plantState = repository.GetPlantState(plantStateId);
			return plantState != null && plantState.UserId == userId;
		}



	}
}