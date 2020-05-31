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
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
	[Authorize]
    [ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
    {
		private readonly IUsersRepository usersRepository;
		private readonly UserManager<ApplicationUser> userManager;

		public UsersController(IUsersRepository usersRepository,
							   UserManager<ApplicationUser> userManager)
		{
			this.usersRepository = usersRepository;
			this.userManager = userManager;
		}

		[HttpGet("{id}")]
		[Route("Current")]
		public async Task<ActionResult<User>> GetCurrentAsync(int id)
		{
			var userGuid = (await userManager.GetUserAsync(User)).Id;
			return usersRepository.GetUser(userGuid);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetAsync(int id)
		{
			return usersRepository.GetUser(id);
		}

		[HttpGet]
		public async Task<IEnumerable<User>> GetAsync()
		{
			return usersRepository.GetUsers();
		}
	}
}