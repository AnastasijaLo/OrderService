namespace OrderService.Data
{
    using Microsoft.EntityFrameworkCore;
    using OrderService.Models;

    /// <summary>
    /// Application database context for managing access to Orders and Receipts data.
    /// </summary>
    public class AppDbContext : DbContext, IAppDbContext
    {
        /// <summary>
        /// Application database context for managing access to Orders and Receipts data.
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Represents the collection of orders stored in the database.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Represents the collection of receipts stored in the database.
        /// </summary>
        public DbSet<Receipt> Receipts { get; set; }
    }
}
