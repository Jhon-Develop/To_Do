using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using To_Do.Models.DTOs;
using To_Do.Services.Interfaces;

namespace To_Do.Controllers.v1.Auth
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [SwaggerOperation(
            Summary = "Here you can register with your basic information",
            Description = "Here you can register with your basic information")]
        [SwaggerResponse(StatusCodes.Status200OK, "Register successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Register failed")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _authService.ResgiterAsync(registerDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [SwaggerOperation(
            Summary = "Here you can login with your email and password",
            Description = "Here you can login with your email and password")]
        [SwaggerResponse(StatusCodes.Status200OK, "Login successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Login failed")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var token = await _authService.LoginAsync(loginDto);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}