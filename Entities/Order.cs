
namespace CQRSOrderManagement.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal OrderAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public List<string> Items { get; set; } = new List<string>();
    }
}
