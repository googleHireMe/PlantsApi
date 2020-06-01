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
using PlantsApi.Models.Dtos;
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
		public ActionResult<PlantStateResponceDto> Get(int id)
		{
			return plantsStateRepository.GetPlantState(id);
		}

		[HttpGet]
		public async Task<IEnumerable<PlantStateResponceDto>> GetAsync()
		{
			var userGuid = (await userManager.GetUserAsync(User)).Id;
			var userId = usersRepository.GetUser(userGuid).Id;
			var result = plantsStateRepository
				.GetPlantStatesForUser(userId)
				.ToList();
			return result;
		}

	}
}