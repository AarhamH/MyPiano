﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public AuthController(IUserRepository repository) 
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new UserModel
            {
                Username = dto.Name, Email = dto.Email, Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            return Created("Success",_repository.Build(user));
        }
    }
}