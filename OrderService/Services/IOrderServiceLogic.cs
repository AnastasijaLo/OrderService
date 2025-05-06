namespace OrderService.Services
{
    using OrderService.DTOs;

    /// <summary>
    /// Order-related operation handling.
    /// </summary>
    public interface IOrderServiceLogic
    {
        /// <summary>
        /// Processes a new order and returns a receipt with the payment result.
        /// </summary>
        /// <param name="orderDto">Order.</param>
        Task<ReceiptDto> ProcessOrderAsync(OrderDto orderDto);

        /// <summary>
        /// Retrieves the order details for a previously processed order by its identifier.
        /// </summary>
        /// <param name="id">Order identifier.</param>
        Task<OrderDto> GetOrderById(long id);
    }
}
