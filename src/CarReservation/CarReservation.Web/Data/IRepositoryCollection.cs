namespace CarReservation.Web.Data;

/// <summary>
/// Define a collection of repositories for different domain entities.
/// </summary>
public interface IRepositoryCollection
{
    /// <summary>
    /// Get cities repository from collection
    /// </summary>
    /// <returns><see cref="ICitiesRepository"/></returns>
    ICitiesRepository Cities();

    /// <summary>
    /// Get cars repository from collection
    /// </summary>
    /// <returns><see cref="ICarsRepository"/></returns>
    ICarsRepository Cars();

    /// <summary>
    /// Get bookings repository from collection
    /// </summary>
    /// <returns<see cref="IBookingsRepository"/>></returns>
    IBookingsRepository Bookings();
}