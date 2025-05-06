namespace OrderService.Services
{
    using OrderService.Models;

    /// <summary>
    /// Processing payments through a payment gateway.
    /// </summary>
    public interface IPaymentGatewayLogic
    {
        /// <summary>
        /// Simulates processing a payment through the fake payment gateway.
        /// </summary>
        /// <param name="order">Order.</param>
        Task<bool> IsPaymentProcessedAsync(Order order);
    }
}
