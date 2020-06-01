using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantsApi.Models;
using PlantsApi.Repository;
using Microsoft.AspNetCore.Identity;
using PlantsApi.Models.Dtos;
using PlantsApi.Models.DbModels;

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
		public IEnumerable<Plant> Get()
		{
			var plants = repository.GetPlants().ToList();
			return plants;
		}


		[HttpGet("{id}")]
		public ActionResult<Plant> Get(int id)
		{
			if (DoesPlantExist(id))
				return repository.GetPlant(id);
			else
				return NotFound();
		}

		[HttpGet]
		[Route("[action]")]
		public ActionResult<PagedQueryResult> SearchPlants(string Filter, int PageNumber, int PageSize)
		{
			var queryDto = new PlantsPagedQueryDto
			{
				Filter = Filter,
				PageNumber = PageNumber,
				PageSize = PageSize
			};
			var query = repository.SearchPlants(queryDto);
			var totalItemCount = query.Count();

			// checks if no items were found
			if (totalItemCount == 0)
				return new PagedQueryResult
				{
					TotalItemsCount = 0,
					TotalPagesCount = 0,
					PageSize = 0,
					Results = new List<Plant>()
				};
			// index for skipping previous pages
			var countToSkip = (queryDto.PageNumber - 1) * (queryDto.PageSize);
            var totalPageCount = (int)Math.Ceiling((decimal)totalItemCount / queryDto.PageSize);
            //checks if the user requested a page that exceeds the query size
            if (countToSkip != 0 && countToSkip >= totalItemCount)
				return BadRequest(new Exception($"User requested page number { queryDto.PageNumber } when there are only { totalPageCount} pages"));

			var entities = query.Skip(countToSkip).Take(queryDto.PageSize).ToList();
			var queryResult = new PagedQueryResult
			{
				TotalItemsCount = totalItemCount,
				TotalPagesCount = totalPageCount,
				PageSize = entities.Count,
				Results = entities
			};
			return queryResult;
		}

		private bool DoesPlantExist(int id) => repository.GetPlant(id) != null;

	}
}
