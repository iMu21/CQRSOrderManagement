namespace CQRSOrderManagement.Models.Auth.Response
{
    public class ForgetPasswordResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
