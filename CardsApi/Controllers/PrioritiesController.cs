using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlantsApi.Models;
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PrioritiesController : ControllerBase
	{
		private INotesRepository repository;

		public PrioritiesController(INotesRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public IEnumerable<Priority> Get() => repository.GetPriorities().ToList();

		[HttpGet("{id}")]
		public ActionResult<Priority> Get(int id)
		{
			var result = repository.GetPriority(id);
			if (result == null) { return NotFound(); }
			return result;
		}
	}
}