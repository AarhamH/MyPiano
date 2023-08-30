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
        
    }
}
