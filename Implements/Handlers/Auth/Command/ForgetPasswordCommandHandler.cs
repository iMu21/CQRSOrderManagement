namespace CQRSOrderManagement.Implements.Handlers.Auth.Command
{
    using System;
    using System.Threading.Tasks;
    using CQRSOrderManagement.Interfaces.Handlers;
    using CQRSOrderManagement.Interfaces.Helpers;
    using CQRSOrderManagement.Models.Auth.Command;
    using CQRSOrderManagement.Models.Auth.Response;
    using Microsoft.EntityFrameworkCore;

    public class ForgetPasswordCommandHandler : ICommandHandler<ForgetPasswordCommand, ForgetPasswordResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public ForgetPasswordCommandHandler(ApplicationDbContext context, IEmailSender emailSender, IJwtTokenGenerator tokenGenerator)
        {
            _context = context;
            _emailSender = emailSender;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ForgetPasswordResponse> HandleAsync(ForgetPasswordCommand command)
        {
            // Check if the user exists by email
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == command.Email);
            if (user == null)
            {
                return new ForgetPasswordResponse
                {
                    Success = false,
                    Message = "User with this email does not exist."
                };
            }

            var resetToken = _tokenGenerator.GenerateToken(user.Email);
            user.PasswordResetToken = resetToken;
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            var resetLink = $"https://yourapp.com/reset-password?token={resetToken}";
            var emailContent = $"Click the following link to reset your password: {resetLink}";

            await _emailSender.SendEmailAsync(user.Email, "Password Reset Request", emailContent);

            return new ForgetPasswordResponse
            {
                Success = true,
                Message = "Password reset email has been sent."
            };
        }
    }

}
