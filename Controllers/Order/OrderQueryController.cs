using CQRSOrderManagement.Interfaces.Dispatchers;
using CQRSOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace CQRSOrderManagement.Controllers.Order
{
    [ApiController]
    [Route("api/order")]
    public class OrderQueryController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public OrderQueryController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _queryDispatcher.DispatchAsync<Guid, OrderQuery>(id);
            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _queryDispatcher.DispatchAsync<bool, List<OrderQuery>>(true);
            return Ok(orders);
        }
    }

}
