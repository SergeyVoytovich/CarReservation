using CarReservation.Web.Domain;

namespace CarReservation.Web.Services;

public interface IBookingService
{
    public Task<IList<City>> GetCities();
}
