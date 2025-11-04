using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;


/// <summary>
/// Defines a repository for retrieving city data.
/// </summary>
/// <remarks>This interface provides an abstraction for accessing city information, allowing for different
/// implementations such as database or in-memory storage.</remarks>
public interface ICitiesRepository : IRepository<City>
{

}
