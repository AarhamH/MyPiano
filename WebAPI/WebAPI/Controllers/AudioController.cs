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

    }
}
