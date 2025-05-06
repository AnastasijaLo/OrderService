namespace OrderService.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents an order entity stored in the database.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Unique identifier of the order.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Order number.
        /// </summary>
        public long OrderNumber { get; set; }

        /// <summary>
        /// User identifier.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Payable amount.
        /// </summary>
        public decimal PayableAmount { get; set; }

        /// <summary>
        /// Payment gateway.
        /// </summary>
        public string PaymentGateway { get; set; } = string.Empty;

        /// <summary>
        /// Payment gateway identifier.
        /// </summary>
        public long GatewayIdentifier { get; set; }

        /// <summary>
        /// Order description.
        /// </summary>
        public string? Description { get; set; }
    }
}
