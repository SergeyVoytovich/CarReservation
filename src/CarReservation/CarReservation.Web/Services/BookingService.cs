using CarReservation.Web.Data;
using CarReservation.Web.Domain;

namespace CarReservation.Web.Services;

internal class BookingService(IRepositoryCollection repositories) : IBookingService
{
    protected virtual IRepositoryCollection Repositories { get; } = repositories;

    public Task<IList<City>> GetCities()
        => Repositories.Cities().GetAsync();

    public Task<City?> GetCityAsync(Guid id)
        => Repositories.Cities().GetAsync(id);

    public async Task<IList<Car>> GetAvailabilityCarsAsync(Guid cityId, DateOnly from, DateOnly till)
    {
        if (cityId == Guid.Empty)
        {
            throw new ArgumentException("City ID cannot be empty.", nameof(cityId));
        }

        if(from < DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentOutOfRangeException("From date cannot be in the past.", nameof(from));
        }

        if(till <= from)
        {
            throw new ArgumentOutOfRangeException("Till date must be after from date.", nameof(till));
        }

        var cars = await Repositories.Cars().GetByCityAsync(cityId);
        return await CeckAvailabilityiesAsync(cars, from, till);
    }

    public async Task<Car?> GetAvailabilityCarAsync(Guid carId, DateOnly from, DateOnly till)
    {
        var car = await Repositories.Cars().GetAsync(carId);
        if(car is null)
        {
            return null;
        }

        return await CeckAvailabilityAsync(car, from, till);
    }

    protected virtual async Task<Car?> CeckAvailabilityAsync(Car car, DateOnly from, DateOnly till)
       => (await CeckAvailabilityiesAsync([car], from, till)).SingleOrDefault();

    protected virtual async Task<IList<Car>> CeckAvailabilityiesAsync(IList<Car> cars, DateOnly from, DateOnly till)
    {
        var bookings = (await Repositories.Bookings().GetAsync(cars.Select(i => i.Id).ToList(), from, till))
                            .Select(i => i.CarId)
                            .Distinct()
                            .ToHashSet();
        return cars.Where(i => !bookings.Contains(i.Id)).ToList();
    }
}
