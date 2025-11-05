using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

internal class BookingsRepository(IEnumerable<Booking> items) : RepositoryBase<Booking>(items), IBookingsRepository
{
    public Task<IList<Booking>> GetAsync(IList<Guid> carsIds, DateOnly from, DateOnly till)
        => Task.FromResult(Get(carsIds, from, till).ToList() as IList<Booking>);

    protected virtual IEnumerable<Booking> Get(IList<Guid> carsIds, DateOnly fromDate, DateOnly tillDate)
        => from item in Items
           join carId in carsIds on item.CarId equals carId
           where fromDate.Between(item.StartDate, item.EndDate) || tillDate.Between(item.StartDate, item.EndDate)
           select item;
}
