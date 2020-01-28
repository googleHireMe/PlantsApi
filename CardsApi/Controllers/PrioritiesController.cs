using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;

namespace CardsApi.Controllers
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