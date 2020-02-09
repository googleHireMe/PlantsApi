using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlantsApi.Models;
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersPlantsController : ControllerBase
    {
		private readonly IPlantsRepository repository;
		private readonly UserManager<ApplicationUser> userManager;

		public UsersPlantsController(IPlantsRepository repository,
									UserManager<ApplicationUser> userManager)
		{
			this.repository = repository;
			this.userManager = userManager;
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<Plant>> GetAsync(int id)
		{
			var user = await GetUserAsync();
			if (user.PlantAssignments.All(pa => pa.PlantId != id))
				return NotFound();

			return repository.GetPlant(id);
		}


		[HttpGet]
		public async Task<IEnumerable<Plant>> GetAsync()
		{
			var user = await GetUserAsync();
			var plantIdsOfUser = user.PlantAssignments.Select(pa => pa.PlantId);

			return repository.GetPlants().Where(p => plantIdsOfUser.Contains(p.Id));
		}


		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] int linkedPlantId)
		{
			var user = await GetUserAsync();
			repository.LinkUserToPlant(user.Id, linkedPlantId);
			return NoContent();
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int linkedPlantId)
		{
			var user = await GetUserAsync();
			repository.DeleteLinkUserToPlant(user.Id, linkedPlantId);
			return NoContent();
		}

		private async Task<User> GetUserAsync()
		{
			var userGuid = (await userManager.GetUserAsync(User)).Id;
			return repository.GetUser(userGuid);
		}

	}
}