using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

internal class CarsRepository(IEnumerable<Car> items) : RepositoryBase<Car>(items), ICarsRepository
{
    public Task<IList<Car>> GetAsync(Guid cityId)
        => Task.FromResult<IList<Car>>(Items.Where(c => c.CityId == cityId).ToList());
}