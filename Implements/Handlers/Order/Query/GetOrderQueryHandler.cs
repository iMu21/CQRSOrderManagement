using CQRSOrderManagement.Interfaces.Handlers;
using CQRSOrderManagement.Models;

namespace CQRSOrderManagement.Services.Handlers.Order.Query
{
    public class GetOrderQueryHandler : IQueryHandler<Guid, OrderQuery>
    {
        private readonly ApplicationDbContext _context;

        public GetOrderQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderQuery> HandleAsync(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) throw new Exception("Not Found");

            // Map the database entity to the query model
            return new OrderQuery
            {
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                ItemsSummary = string.Join(", ", order.Items),
                OrderDate = order.OrderDate
            };
        }
    }

}
