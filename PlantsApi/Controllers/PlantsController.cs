using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantsApi.Models;
using PlantsApi.Repository;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace PlantsApi.Controllers
{
	// TODO: add role 'Admin' for editing
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class PlantsController : ControllerBase
	{
		private readonly IPlantsRepository repository;
		private readonly UserManager<ApplicationUser> userManager;

		public PlantsController(IPlantsRepository repository,
								UserManager<ApplicationUser> userManager)
		{
			this.repository = repository;
			this.userManager = userManager;
		}

		[HttpGet]
        public async Task<IEnumerable<Plant>> GetAsync()
        {
			var userId = await userManager.GetUserAsync(User);
			var plants = repository.GetPlants().ToList();
			return plants;
        }


        [HttpGet("{id}")]
		public async Task<ActionResult<Plant>> GetAsync(int id)
		{
			if (DoesPlantExist(id))
				return repository.GetPlant(id);
			else
				return NotFound();
		}

		[HttpPost]
		public IActionResult Post([FromBody] Plant value)
		{
			var created = repository.CreatePlant(value);
			return CreatedAtAction(nameof(GetAsync), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Plant value)
		{
			if (id != value.Id) { return BadRequest(); }
			try
			{
				repository.UpdatePlant(value);
				return NoContent();
			}
			catch (Exception)
			{
				if (!DoesPlantExist(id)) { return NotFound(); }
				else { throw; }
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			try
			{
				repository.DeletePlant(id);
				return NoContent();
			}
			catch (Exception)
			{
				if (!DoesPlantExist(id)) { return NotFound(); }
				else { throw; }
			}
		}

		private bool DoesPlantExist(int id) => repository.GetPlant(id) != null;

	}
}
