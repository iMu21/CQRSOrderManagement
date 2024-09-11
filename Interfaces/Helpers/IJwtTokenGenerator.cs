namespace CQRSOrderManagement.Interfaces.Helpers
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string email);
    }
}
