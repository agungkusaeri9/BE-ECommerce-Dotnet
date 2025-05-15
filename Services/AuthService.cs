using backend_dotnet.Data;
using backend_dotnet.DTOs;
using backend_dotnet.DTOs.Authentication;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtService _jwtService;

        public AuthService(AppDbContext context, IPasswordHasher<User> passwordHasher, IJwtService jwtService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<UserDTO> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = _passwordHasher.HashPassword(new User(), request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (user == null)
                throw new Exception("Invalid email or password");

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid email or password");

            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                User = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                }
            };
        }

    }
}