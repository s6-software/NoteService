using Microsoft.AspNetCore.Mvc;
using Models;
using Services.MongoDBService;

namespace NoteService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        private readonly MongoDBService _mongoDBService;
        public NoteController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        [HttpGet]
        public async Task<List<Note>> Get()
        {
            List<Note> notes = await _mongoDBService.GetAllAsync();
            return notes;
        }

        // GET: api/note/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // TODO: Implement logic to retrieve a specific note from the database based on the provided id
            return Ok();
        }

        // POST: api/note
        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            // TODO: Implement logic to create a new note in the database based on the provided note object
            return CreatedAtAction(nameof(Get), new { id = note.Id }, note);
        }

        // PUT: api/note/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Note note)
        {
            // TODO: Implement logic to update an existing note in the database based on the provided id and note object
            return NoContent();
        }

        // DELETE: api/note/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Implement logic to delete a specific note from the database based on the provided id
            return NoContent();
        }
    }
}
