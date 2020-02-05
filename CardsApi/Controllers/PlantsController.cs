using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantsApi.Models;
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantsRepository repository;

        public PlantsController(IPlantsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Plant> Get() => repository.GetPlants().ToList();

        [HttpGet("{id}")]
        public ActionResult<Plant> Get(int id)
        {
            var result = repository.GetPlant(id);
            if (result == null) { return NotFound(); }
            return result;
        }
	}
}
