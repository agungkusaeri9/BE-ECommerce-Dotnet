using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.DTOs;
using backend_dotnet.DTOs.Authentication;
using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces
{
    public interface IAuthService
    {
        Task<UserDTO> RegisterAsync(RegisterRequest request);
        Task<LoginResponseDto> LoginAsync(LoginRequest request);
    }
}