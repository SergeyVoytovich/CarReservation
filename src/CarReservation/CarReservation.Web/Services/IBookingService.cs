using CarReservation.Web.Domain;

namespace CarReservation.Web.Services;

public interface IBookingService
{
    Task<IList<City>> GetCities();
    Task<City?> GetCityAsync(Guid id);
    Task<IList<City>> GetCitiesAsync(IList<Guid> ids);
    Task<IList<Car>> GetCarsAsync(IList<Guid> ids);
    Task<Car?> GetAvailabilityCarAsync(Guid carId, DateOnly from, DateOnly till);
    Task<IList<Car>> GetAvailabilityCarsAsync(Guid cityId, DateOnly from, DateOnly till);
    Task<BookingResult> BookAsync(Booking booking);
    Task<IList<Booking>> GetBookingsAsync();
}