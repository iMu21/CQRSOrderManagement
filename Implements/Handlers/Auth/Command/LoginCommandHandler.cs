namespace CQRSOrderManagement.Implements.Handlers.Auth.Command
{
    using System;
    using System.Threading.Tasks;
    using CQRSOrderManagement.Interfaces.Handlers;
    using CQRSOrderManagement.Interfaces.Helpers;
    using CQRSOrderManagement.Models.Auth.Command;
    using CQRSOrderManagement.Models.Auth.Response;
    using Microsoft.EntityFrameworkCore;

    public class LoginCommandHandler : ICommandHandler<LoginCommand, AuthResponse>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ApplicationDbContext _context;

        public LoginCommandHandler(IJwtTokenGenerator jwtTokenGenerator, ApplicationDbContext context)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _context = context;
        }

        public async Task<AuthResponse> HandleAsync(LoginCommand command)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == command.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User does not exist.");
            }

            if (!BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid password.");
            }

            user.LastLogin = DateTime.UtcNow;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(user.Email);

            return new AuthResponse
            {
                Email = user.Email,
                Token = token
            };
        }
    }
}
