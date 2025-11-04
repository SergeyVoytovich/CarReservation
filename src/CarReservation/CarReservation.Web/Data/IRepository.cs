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
}
