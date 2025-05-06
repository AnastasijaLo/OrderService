namespace OrderService.Services
{
    using OrderService.Models;

    /// <summary>
    /// Simulates a fake payment gateway to process payments for testing purpose.
    /// </summary>
    public class PaymentGatewayLogic : IPaymentGatewayLogic
    {
        /// <summary>
        /// Simulates processing a payment through the fake payment gateway.
        /// </summary>
        /// <param name="order">Order.</param>
        public Task<bool> IsPaymentProcessedAsync(Order order)
        {
            return Task.FromResult(order.PayableAmount > 0);
        }
    }
}
