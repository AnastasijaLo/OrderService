namespace OrderService.DTOs
{
    /// <summary>
    /// Data transfer object representing the result of a processed order.
    /// </summary>
    public class ReceiptDto
    {
        /// <summary>
        /// Unique identifier of the receipt.
        /// </summary>
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
        public string? Message { get; set; }

        /// <summary>
        /// Date when the order was created.
        /// </summary>
        public DateTime OrderDate { get; set; }
    }
}
