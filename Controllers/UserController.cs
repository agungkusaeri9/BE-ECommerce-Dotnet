using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Data;
using backend_dotnet.DTOs;
using backend_dotnet.DTOs.User;
using backend_dotnet.Entities;
using backend_dotnet.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserController(AppDbContext appDbContext, IPasswordHasher<User> passwordHasher)
        {
            _appDbContext = appDbContext;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            if (page < 1) page = 1;
            if (limit < 1) limit = 10;

            var totalUsers = await _appDbContext.Users.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalUsers / limit);

            var users = await _appDbContext.Users
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(user => new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.Role
                })
                .ToListAsync();

            var paginatedResult = new PaginationMeta<object>
            {
                // Data = users,
                CurrentPage = page,
                ItemsPerPage = limit,
                TotalItems = totalUsers,
                TotalPages = totalPages
            };

            return ResponseFormatter.Success(users, "Users found successfully", pagination: paginatedResult);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreateRequest request)
        {
            try
            {
                var newUser = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    Role = request.Role
                };

                newUser.Password = _passwordHasher.HashPassword(newUser, request.Password);

                await _appDbContext.Users.AddAsync(newUser);
                await _appDbContext.SaveChangesAsync();

                var userResponse = new UserResponse
                {
                    Id = newUser.Id,
                    Name = newUser.Name,
                    Email = newUser.Email,
                    Role = newUser.Role
                };
                return ResponseFormatter.Success(userResponse, "User created successfully");
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error("Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _appDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
                if (user == null)
                {
                    return ResponseFormatter.NotFound("User not found");
                }

                var userResponse = new UserResponse
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role
                };

                return ResponseFormatter.Success(userResponse, "User found successfully");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserUpdateRequest request)
        {
            try
            {
                var user = await _appDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
                if (user == null)
                {
                    return ResponseFormatter.NotFound("User not found");
                }

                user.Name = request.Name;
                user.Email = request.Email;
                if (request.Password != null)
                {
                    user.Password = _passwordHasher.HashPassword(user, request.Password);
                }

                await _appDbContext.SaveChangesAsync();

                return ResponseFormatter.Success(user, "User updated successfully");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var user = await _appDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
                if (user == null)
                {
                    return ResponseFormatter.NotFound("User not found");
                }

                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();

                return ResponseFormatter.Success(null, "User deleted successfully");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}