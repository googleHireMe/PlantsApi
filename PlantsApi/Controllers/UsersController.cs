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
	public class UsersController : ControllerBase
    {
		private readonly IPlantsRepository repository;
		private readonly UserManager<ApplicationUser> userManager;

		public UsersController(IPlantsRepository repository,
								UserManager<ApplicationUser> userManager)
		{
			this.repository = repository;
			this.userManager = userManager;
		}

		[HttpGet("{id}")]
		[Route("Current")]
		public async Task<ActionResult<User>> GetCurrentAsync(int id)
		{
			var userGuid = (await userManager.GetUserAsync(User)).Id;
			return repository.GetUser(userGuid);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetAsync(int id)
		{
			return repository.GetUser(id);
		}

		[HttpGet]
		public async Task<IEnumerable<User>> GetAsync()
		{
			return repository.GetUsers();
		}
	}
}