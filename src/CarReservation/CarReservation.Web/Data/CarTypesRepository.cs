
using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

internal class CarTypesRepository(IEnumerable<CarType> items) : RepositoryBase<CarType>(items), ICarTypesRepository
{
    public Task<IList<CarType>> GetByIdsAsync(IList<Guid> ids)
        => Task.FromResult<IList<CarType>>(Items.Where(i => ids.Contains(i.Id)).ToList());

}