using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

/// <summary>
/// Defines a repository for retrieving car types.
/// </summary>
/// <remarks>This interface provides a method to asynchronously retrieve a collection of car types.
/// Implementations of this interface should handle data access and ensure thread safety if required.</remarks>
public interface ICarTypesRepository : IRepository<CarType>
{
    /// <summary>
    /// Get car types by their unique identifiers asynchronously.
    /// </summary>
    /// <param name="ids">List of identifiers</param>
    /// <returns>A list of <see cref="CarType"/></returns>
    public Task<IList<CarType>> GetByIdsAsync(IList<Guid> ids);
}
