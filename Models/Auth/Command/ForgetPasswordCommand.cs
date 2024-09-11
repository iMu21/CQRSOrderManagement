namespace CQRSOrderManagement.Models.Auth.Command
{
    public class ForgetPasswordCommand
    {
        public string Email { get; set; } = string.Empty;
    }
}
