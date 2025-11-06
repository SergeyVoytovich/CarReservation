namespace CarReservation.Web.Data;

/// <summary>
/// Defines a generic repository interface for data access operations.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Gets all items of type T asynchronously.
    /// </summary>
    /// <returns>A list of items</returns>
    Task<IList<T>> GetAsync();

    /// <summary>
    /// Gets all items of type T asynchronously by specified identidiers
    /// </summary>
    /// <returns>A list of items</returns>
    Task<IList<T>> GetAsync(IList<Guid> ids);

    /// <summary>
    /// Gets an item of type T by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">Unicue identifier</param>
    /// <returns>Item</returns>
    Task<T?> GetAsync(Guid id);
}
