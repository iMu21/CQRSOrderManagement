using CQRSOrderManagement.Entities;
using CQRSOrderManagement.Interfaces.Handlers;
using CQRSOrderManagement.Interfaces.Helpers;
using CQRSOrderManagement.Models.Auth.Command;
using CQRSOrderManagement.Models.Auth.Response;
using Microsoft.EntityFrameworkCore;

namespace CQRSOrderManagement.Implements.Handlers.Auth.Command
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, AuthResponse>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ApplicationDbContext _context;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, ApplicationDbContext context)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _context = context;
        }

        public async Task<AuthResponse> HandleAsync(RegisterCommand command)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Email == command.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);

            var user = new User
            {
                Email = command.Email,
                PasswordHash = passwordHash,
                FullName = command.FullName,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(command.Email);

            return new AuthResponse { Email = command.Email, Token = token };
        }
    }
}
