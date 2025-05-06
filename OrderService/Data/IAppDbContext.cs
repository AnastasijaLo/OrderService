namespace OrderService.Data
{
    using Microsoft.EntityFrameworkCore;
    using OrderService.Models;

    /// <summary>
    /// Interface for the database context.
    /// </summary>
    public interface IAppDbContext
    {
        /// <summary>
        /// Represents the collection of orders stored in the database.
        /// </summary>
        DbSet<Order> Orders { get; }

        /// <summary>
        /// Represents the collection of receipts stored in the database.
        /// </summary>
        DbSet<Receipt> Receipts { get; }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
