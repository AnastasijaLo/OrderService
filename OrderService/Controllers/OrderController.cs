namespace OrderService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OrderService.DTOs;
    using OrderService.Endpoints;
    using OrderService.Models;
    using OrderService.Services;

    /// <summary>
    /// Order-related API request handling.
    /// </summary>
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServiceLogic _orderService;
        private readonly ILogger<OrdersController> _logger;

        /// <summary>
        /// Order-related API request handling.
        /// </summary>
        public OrdersController(IOrderServiceLogic orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a processed order by identifier.
        /// </summary>
        [HttpGet(Orders.GetById)]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderDto>> GetOrderById(long id)
        {
            try
            {
                var receivedOrder = await _orderService.GetOrderById(id);
                return receivedOrder == null ? NotFound() : Ok(receivedOrder);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching order {id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error.");
            }
        }

        /// <summary>
        /// Processes a new order and returns a receipt upon successful payment.
        /// </summary>
        [HttpPost(Orders.Base)]
        public async Task<ActionResult<Order>> PostOrder([FromBody] OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var order = await _orderService.ProcessOrderAsync(orderDto);
                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while processing the order.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
