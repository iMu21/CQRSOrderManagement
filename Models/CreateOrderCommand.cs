namespace CQRSOrderManagement.Models
{
    public class CreateOrderCommand
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<string> Items { get; set; } = new List<string>();
        public DateTime OrderDate { get; set; }
    }

}
