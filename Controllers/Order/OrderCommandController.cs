using CQRSOrderManagement.Interfaces.Dispatchers;
using CQRSOrderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CQRSOrderManagement.Controllers.Order
{
    [ApiController]
    [Route("api/order")]
    public class OrderCommandController : ControllerBase
    {
        private readonly ICommandDispatcher _dispatcher;

        public OrderCommandController(ICommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create order", Description = "Create a new order")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _dispatcher.DispatchAsync<CreateOrderCommand, bool>(command);
            return Ok("Order created successfully");
        }
    }

}
