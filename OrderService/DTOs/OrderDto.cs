namespace OrderService.DTOs
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Data transfer object representing an order submitted by a user.
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Unique identifier of the order.
        /// </summary>
        [Required(ErrorMessage = "Identifier is required.")]
        public long Id { get; set; }

        /// <summary>
        /// Order number.
        /// </summary>
        [Required(ErrorMessage = "Order number is required.")]
        public long OrderNumber { get; set; }

        /// <summary>
        /// User identifier.
        /// </summary>
        [Required(ErrorMessage = "User identifier is required.")]
        public long UserId { get; set; }

        /// <summary>
        /// Payable amount.
        /// </summary>
        [Range(0.01, double.MaxValue, ErrorMessage = "Payable amount must be greater than zero.")]
        public decimal PayableAmount { get; set; }

        /// <summary>
        /// Payment gateway.
        /// </summary>
        [Required(ErrorMessage = "Payment gateway is required.")]
        public string PaymentGateway { get; set; } = string.Empty;

        /// <summary>
        /// Payment gateway identifier.
        /// </summary>
        [Required(ErrorMessage = "Gateway identifier is required.")]
        public long GatewayIdentifier { get; set; }

        /// <summary>
        /// Order description.
        /// </summary>
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
