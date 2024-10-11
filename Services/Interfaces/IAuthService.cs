using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do.Models.DTOs;

namespace To_Do.Services.Interfaces
{
    public interface IAuthService
    {
        Task ResgiterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}