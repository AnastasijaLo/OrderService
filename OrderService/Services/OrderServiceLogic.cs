namespace OrderService.Services
{
    using OrderService.Data;
    using OrderService.DTOs;
    using OrderService.Models;

    /// <summary>
    /// Logic for processing orders.
    /// </summary>
    public class OrderServiceLogic : IOrderServiceLogic
    {
        private readonly IAppDbContext _dbContext;
        private readonly IPaymentGatewayLogic _paymentGateway;

        /// <summary>
        /// Logic for processing orders.
        /// </summary>
        public OrderServiceLogic(IAppDbContext dbContext, IPaymentGatewayLogic paymentgateway)
        {
            _dbContext = dbContext;
            _paymentGateway = paymentgateway;
        }

        /// <summary>
        /// Processes a new order and returns a receipt with the payment result.
        /// </summary>
        /// <param name="orderDto">Order.</param>
        /// <returns></returns>
        public async Task<ReceiptDto> ProcessOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                Id = orderDto.Id,
                OrderNumber = orderDto.OrderNumber,
                UserId = orderDto.UserId,
                PayableAmount = orderDto.PayableAmount,
                PaymentGateway = orderDto.PaymentGateway,
                GatewayIdentifier = orderDto.GatewayIdentifier,
                Description = orderDto.Description,
            };
            
            bool isPaymentSuccessful = await _paymentGateway.IsPaymentProcessedAsync(order);
            if (!isPaymentSuccessful)
            {
                throw new Exception("Payment failed.");
            }

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            var receipt =  new Receipt
            {
                Id=orderDto.Id,
                OrderNumber = order.OrderNumber,
                IsSuccessful = isPaymentSuccessful,
                Message = "Message",
                Timestamp = DateTime.Now,
            };

            _dbContext.Receipts.Add(receipt);
            await _dbContext.SaveChangesAsync();

            return new ReceiptDto
            {
                Id = receipt.Id,
                OrderNumber = receipt.OrderNumber,
                IsSuccessful = receipt.IsSuccessful,
                Message = receipt.Message,
                OrderDate = receipt.Timestamp,
            };
        }

        /// <summary>
        /// Retrieves the order details for a previously processed order by its identifier.
        /// </summary>
        /// <param name="id">Order identifier.</param>
        public async Task<OrderDto> GetOrderById(long id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null)
            {
                return null;
            }

            return new OrderDto
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                UserId = order.UserId,
                PayableAmount = order.PayableAmount,
                PaymentGateway = order.PaymentGateway,
                GatewayIdentifier = order.GatewayIdentifier,
                Description = order.Description,
            };
        }
    }
}
