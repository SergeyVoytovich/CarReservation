using CarReservation.Web.Data;
using CarReservation.Web.Domain;

namespace CarReservation.Web.Services;

internal class BookingService(IRepositoryCollection repositories) : IBookingService
{
    protected virtual IRepositoryCollection Repositories { get; } = repositories;

    public async Task<IList<City>> GetCities()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        return await Repositories.Cities().GetAsync();
    }

    public async Task<City?> GetCityAsync(Guid id)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        return  await Repositories.Cities().GetAsync(id);
    }

    public async Task<IList<Car>> GetAvailabilityCarsAsync(Guid cityId, DateOnly from, DateOnly till)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));

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
        return await CheckAvailabilityiesAsync(cars, from, till);
    }

    public async Task<Car?> GetAvailabilityCarAsync(Guid carId, DateOnly from, DateOnly till)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));

        if (carId == Guid.Empty)
        {
            throw new ArgumentException("Car ID cannot be empty.", nameof(carId));
        }

        if (from < DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentOutOfRangeException("From date cannot be in the past.", nameof(from));
        }

        if (till <= from)
        {
            throw new ArgumentOutOfRangeException("Till date must be after from date.", nameof(till));
        }

        var car = await Repositories.Cars().GetAsync(carId);
        if(car is null)
        {
            return null;
        }

        return await CheckAvailabilityAsync(car, from, till);
    }



    protected virtual async Task<Car?> CheckAvailabilityAsync(Car car, DateOnly from, DateOnly till)
       => (await CheckAvailabilityiesAsync([car], from, till)).SingleOrDefault();

    protected virtual async Task<IList<Car>> CheckAvailabilityiesAsync(IList<Car> cars, DateOnly from, DateOnly till)
    {
        var bookings = (await Repositories.Bookings().GetAsync(cars.Select(i => i.Id).ToList(), from, till))
                            .Select(i => i.CarId)
                            .Distinct()
                            .ToHashSet();
        return cars.Where(i => !bookings.Contains(i.Id)).ToList();
    }

    public async Task<BookingResult> BookAsync(Booking booking)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));

        if (booking.CarId == Guid.Empty)
        {
            throw new ArgumentNullException("Car is undefined", nameof(Booking.CarId));
        }

        if(booking.StartDate < DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentOutOfRangeException("Start date cannot be in the past.", nameof(Booking.StartDate));
        }

        if(booking.EndDate <= booking.StartDate)
        {
            throw new ArgumentOutOfRangeException("End date must be after start date.", nameof(Booking.EndDate));
        }

        var car = await Repositories.Cars().GetAsync(booking.CarId);
        car = await CheckAvailabilityAsync(car, booking.StartDate, booking.EndDate);

        if (car is null)
        {
            return BookingResult.CarIsNotAvailable;
        }

        await Repositories.Bookings().AddAsync(booking);
        return BookingResult.Succes;
    }


}
