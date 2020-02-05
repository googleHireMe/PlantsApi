using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlantsApi.Models;
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private INotesRepository repository;

        public ColorsController(INotesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Color> Get() => repository.GetColors().ToList();

        [HttpGet("{id}")]
        public ActionResult<Color> Get(int id)
        {
            var result = repository.GetColor(id);
            if (result == null) { return NotFound(); }
            return result;
        }
    }
}