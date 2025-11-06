using CarReservation.Web.Domain;

namespace CarReservation.Web.Services;

public static class BookingServiceExtensions
{
    public static Task<City?> GetCityAscyn(this IBookingService service, Car car) => service.GetCityAsync(car.CityId);

    public static Task<IList<City>> GetCitiesAsync(this IBookingService service, IEnumerable<Car> cars)
        => service.GetCitiesAsync(cars.Select(c => c.CityId).Distinct().ToList());

    public static Task<IList<Car>> GetCarsAsync(this IBookingService service, IEnumerable<Booking> bookings)
        => service.GetCarsAsync(bookings.Select(b => b.CarId).Distinct().ToList());
}
