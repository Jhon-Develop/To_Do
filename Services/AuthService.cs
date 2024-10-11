using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using To_Do.DataBase;
using To_Do.Models;
using To_Do.Models.DTOs;
using To_Do.Repositories.Interfaces;
using To_Do.Services.Interfaces;

namespace To_Do.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public AuthService(ApplicationDbContext context, IJwtService jwtService, IPasswordHasher passwordHasher, IUserRepository userRepository)
        {
            _context = context;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task ResgiterAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = _passwordHasher.HashPassword(registerDto.PasswordHash)
            };

            await _userRepository.AddUserAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        { 
            var user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);

            if (user == null)
            {
                throw new InvalidOperationException("The user does not exist");
            }

            if (!_passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                throw new InvalidOperationException("The password is incorrect");
            }

            return _jwtService.GenerateToken(user);
        }

    }
}