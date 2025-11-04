using CarReservation.Web.Data;
using CarReservation.Web.Domain;

namespace CarReservation.Web.Services;

internal class BookingService(IRepositoryCollection repositories) : IBookingService
{
    protected virtual IRepositoryCollection Repositories { get; } = repositories;

    public Task<IList<City>> GetCities()
        => Repositories.Cities().GetAsync();
}
