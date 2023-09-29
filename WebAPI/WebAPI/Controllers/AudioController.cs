using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _repository;
        public AudioController(AppDbContext context, IUserRepository repository)
        {
            _context = context;
            _repository = repository;
        }

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

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(AudioModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var audio = await _context.Audios.Where(audio => audio.UserId == userId).ToListAsync();
            return audio == null ? NotFound() : Ok(audio);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(AudioModel model)
        {
            var user = await _context.Users.FindAsync(model.UserId);
            model.UserModel = user;
            await _context.Audios.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok(model.UserModel.Username);
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

            var audioTitle = audioToDelete.Title+".webm";
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            string totlaPath = Path.Combine(folderPath, audioTitle);

            try
            {
                // Delete the file
                if (System.IO.File.Exists(totlaPath))
                {
                    System.IO.File.Delete(totlaPath);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., log the error
                Console.WriteLine($"Error deleting file: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


            if (audioToDelete == null) { return NotFound(); }

            _context.Audios.Remove(audioToDelete);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("upload")]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            // Check if a file was provided
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Get the file name
            string fileName = file.FileName;

            // Specify the folder where you want to save the file
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            // Create the folder if it doesn't exist
            Directory.CreateDirectory(folderPath);

            // Combine the folder path with the file name
            string filePath = Path.Combine(folderPath, fileName);

            // Save the file to the specified path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new {FilePath = filePath});
        }


        [HttpGet("audio/{audioFileName}")]
        public IActionResult GetAudio(string audioFileName)
        {
            // Determine the file path based on the audioFileName
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", audioFileName);

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            // Return the audio file as a stream
            var fileStream = new FileStream(filePath, FileMode.Open);
            return File(fileStream, "audio/mpeg"); // Change the MIME type as needed
        }
    }
}
