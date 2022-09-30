using DnDWebAPI.Data;
using DnDWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DnDWebAPI.Controllers
{
   
    //[Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterDbContext _context;
        public CharacterController(CharacterDbContext context) => _context = context;

        // Implement the Read/Get action on all game characters in the database
        [HttpGet("api/Characters")]
        public async Task<IEnumerable<Character>> Get()
            => await _context.Characters.ToListAsync();

        // Implement the Read/Get action on a specific game character by using an Id
        //[HttpGet("{id}")]
        [HttpGet("api/[controller]/{id}")]
        [ProducesResponseType(typeof(Character), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var gamechar = await _context.Characters.FindAsync(id);

            // The NotFound() will generate a 404 status code in the status response
            // The Ok() will generate a 200 status code in the status response
            return gamechar == null ? NotFound() : Ok(gamechar);

        }

        // Implement the Create action on a game character
        //[HttpPost]
        [HttpPost("api/[controller]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Character gamechar)
        {
            await _context.Characters.AddAsync(gamechar);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = gamechar.Id }, gamechar);

        }

        // Implement the Update action on a game character
        //[HttpPut("{id}")]
        [HttpPut("api/[controller]/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Character gamechar)
        {
            if (id != gamechar.Id) return BadRequest();

            _context.Entry(gamechar).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Implement the Delete action to remove a game character
        //[HttpDelete("{id}")]
        [HttpDelete("api/[controller]/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var gamecharToDelete = await _context.Characters.FindAsync(id);
            if (gamecharToDelete == null) return NotFound();

            _context.Characters.Remove(gamecharToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
