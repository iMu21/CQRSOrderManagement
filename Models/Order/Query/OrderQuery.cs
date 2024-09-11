namespace CQRSOrderManagement.Models.Order.Query
{
    public class OrderQuery
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ItemsSummary { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
    }

}
