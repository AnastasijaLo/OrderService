namespace OrderService.Endpoints
{
    /// <summary>
    /// Route definitions for order-related endpoints.
    /// </summary>
    public static class Orders
    {
        /// <summary>
        /// Base route for accessing order-related endpoints.
        /// </summary>
        public const string Base = "api/orders";

        /// <summary>
        /// Route for retrieving a specific order by its identifier.
        /// </summary>
        public const string GetById = Base + "/{id}";
    }
}
