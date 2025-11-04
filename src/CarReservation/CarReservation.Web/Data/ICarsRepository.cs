using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

/// <summary>
/// Defines a repository for retrieving car data.
/// </summary>
/// <remarks>This interface provides a method to asynchronously retrieve a collection of cars based on a specified city identifier.
public interface ICarsRepository
{
    /// <summary>
    /// Get all cars for a specific city asynchronously.
    /// </summary>
    /// <param name="cityId">City identifier <see cref="City"/></param>
    /// <returns>A list of <see cref="Car>"/></returns>
    Task<IList<Car>> GetAsync(Guid cityId);
}
