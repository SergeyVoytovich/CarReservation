using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

internal class CitiesRepository(IEnumerable<City> items) : RepositoryBase<City>(items), ICitiesRepository
{
}