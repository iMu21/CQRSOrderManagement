using CQRSOrderManagement.Interfaces.Handlers;
using CQRSOrderManagement.Models.Order.Command;

namespace CQRSOrderManagement.Services.Handlers.Order.Command
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public CreateOrderCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HandleAsync(CreateOrderCommand order)
        {
            // Map the command model to the database entity
            var newOrder = new Entities.Order
            {
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                Items = order.Items,
                OrderDate = order.OrderDate
            };
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return true;
        }

        // Additional methods for Update, Delete can be added here
    }

}
