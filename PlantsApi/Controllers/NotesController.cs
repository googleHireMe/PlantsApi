using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantsApi.Models;
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INotesRepository repository;

        public NotesController(INotesRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public IEnumerable<Note> Get()
        {
            var result = repository.GetNotes().ToList();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
			var result = repository.GetNote(id);
			if (result == null) { return NotFound(); }
			return result;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Note value)
        {
            var created = repository.CreateNote(value);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Note value)
		{
			if (id != value.Id) { return BadRequest(); }
			try
			{
				repository.UpdateNote(value);
			}
			catch (Exception)
			{
				if (!DoesNoteExist(id)) { return NotFound(); }
				else { throw; }
			}
            return NoContent();
        }

		[HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                repository.DeleteNote(id);
            }
            catch (Exception)
            {
                if (!DoesNoteExist(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

		private bool DoesNoteExist(int id) => repository.GetNote(id) != null;

	}
}