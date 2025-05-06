namespace OrderService.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a receipt entity stored in the database after processing an order.
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// Unique identifier of the receipt.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Order number.
        /// </summary>
        public long OrderNumber { get; set; }

        /// <summary>
        /// Indicates wheather the order was processed successfully.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Message describing the outcome of the processing.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Date when the order was created.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
