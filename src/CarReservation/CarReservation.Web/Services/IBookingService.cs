using CarReservation.Web.Domain;

namespace CarReservation.Web.Services;

public interface IBookingService
{
    public Task<IList<City>> GetCities();
    public Task<City?> GetCityAsync(Guid id);
    public Task<Car?> GetAvailabilityCarAsync(Guid carId, DateOnly from, DateOnly till);
    public Task<IList<Car>> GetAvailabilityCarsAsync(Guid cityId, DateOnly from, DateOnly till);
}
