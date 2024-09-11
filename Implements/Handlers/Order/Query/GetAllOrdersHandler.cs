using CQRSOrderManagement.Interfaces.Handlers;
using CQRSOrderManagement.Models.Order.Query;
using Microsoft.EntityFrameworkCore;

namespace CQRSOrderManagement.Services.Handlers.Order.Query
{
    public class GetAllOrdersHandler : IQueryHandler<bool, List<OrderQuery>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllOrdersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderQuery>> HandleAsync(bool dummy)
        {
            return await _context.Orders.Select(order => new OrderQuery
            {
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                ItemsSummary = string.Join(", ", order.Items),
                OrderDate = order.OrderDate
            }).ToListAsync();
        }
    }
}
