using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly JWTService _jwtService;
        public AuthController(IUserRepository repository, JWTService jwtservice) 
        {
            _repository = repository;
            _jwtService = jwtservice;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new UserModel
            {
                Username = dto.Username, Email = dto.Email, Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            return Created("Success",_repository.Build(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            if(user == null)
            {
                return BadRequest(new {message = "Invalid Credentials"});
            }

            if(!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly = true });

            return Ok(new
            {
                jwt
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Ok(user);
            }

            catch (Exception _)
            {
                return Unauthorized();
            }
        }
    }
}
