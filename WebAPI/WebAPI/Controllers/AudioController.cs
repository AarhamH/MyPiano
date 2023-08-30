using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AudioController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task <IEnumerable<AudioModel>> Get()
            => await _context.Audios.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(AudioModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var audio = await _context.Audios.FindAsync(id);
            return audio == null ? NotFound() : Ok(audio);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(AudioModel model)
        {
            await _context.Audios.AddAsync(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByID), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update(int id, AudioModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var audioToDelete = await _context.Audios.FindAsync(id);

            if (audioToDelete == null) { return NotFound(); }

            _context.Audios.Remove(audioToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
