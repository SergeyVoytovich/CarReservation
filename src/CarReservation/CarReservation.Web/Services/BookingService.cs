using CarReservation.Web.Data;
using CarReservation.Web.Domain;

namespace CarReservation.Web.Services;

internal class BookingService(IRepositoryCollection repositories) : IBookingService
{
    protected virtual IRepositoryCollection Repositories { get; } = repositories;

    public Task<IList<City>> GetCities()
        => Repositories.Cities().GetAsync();

    public Task<IList<Car>> SearchCarsAsync(Guid cityId, DateOnly from, DateOnly till)
        => Repositories.Cars().GetAsync(cityId); //need to filter by current bookings
}
