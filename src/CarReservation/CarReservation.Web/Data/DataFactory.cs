using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

internal class DataFactory
{
    private const int MinCarsPerCity = 5;
    private const int MaxCarsPerCity = 9;
    private const int MinPrice = 50;
    private const int MaxPrice = 150;
    private const int BookingCount = 10;
    private const int MaxBookingDays = 10;

    public DataSource Init() => Init(Cities().ToList());

    public DataSource Init(IList<City> cities)
    {
        var cars = Cars(cities).ToList();
        var result = new DataSource
        {
            Cities = cities,
            Cars = cars,
            Bookings = Bookings(cars).ToList()
        };
        return result;
    }

    private IEnumerable<City> Cities()
    {
        yield return new City { Id = Guid.NewGuid(), Name = "Berlin" };
        yield return new City { Id = Guid.NewGuid(), Name = "Munich" };
        yield return new City { Id = Guid.NewGuid(), Name = "Hamburg" };
        yield return new City { Id = Guid.NewGuid(), Name = "Frankfurt" };
        yield return new City { Id = Guid.NewGuid(), Name = "Stuttgart" };
    }


    private IEnumerable<(string Make, string Model)> CarTypes()
    {
        yield return new("Volkswagen", "Golf");
        yield return new("BMW", "3 Series");
        yield return new("Audi", "A4");
        yield return new("Mercedes-Benz", "C-Class");
        yield return new("Toyota", "Corolla");
        yield return new("Ford", "Focus");
        yield return new("Honda", "Civic");
        yield return new("Tesla", "Model 3");
        yield return new("Mazda", "6");
        yield return new("Škoda", "Octavia");
    }

    private IEnumerable<Car> Cars(IEnumerable<City> cities)
    {
        var random = new Random();

        var carTypes = CarTypes().ToList();

        foreach (var city in cities)
        {
            for (int i = 0; i < random.Next(MinCarsPerCity, MaxCarsPerCity); i++)
            {
                var carType = carTypes.ElementAt(random.Next(carTypes.Count()));

                yield return new Car
                {
                    Id = Guid.NewGuid(),
                    CityId = city.Id,
                    Make = carType.Make,
                    Model = carType.Model,
                    LicensePlate = $"{city.Name[..1].ToUpperInvariant()}-{random.Next(1000, 9999)}",
                    PricePerDay = random.Next(MinPrice, MaxPrice)
                };
            }
        }
    }

    private IEnumerable<Booking> Bookings(IList<Car> cars)
    {
        var random = new Random();

        for (int i = 0; i < BookingCount; i++)
        {
            var start = DateOnly.FromDateTime(DateTime.Now.AddDays(random.Next(-1 * MaxBookingDays, MaxBookingDays)));
            var end = start.AddDays(random.Next(1, MaxBookingDays));
            var car = cars.ElementAt(random.Next(cars.Count));
            yield return new Booking
            {
                Id = Guid.NewGuid(),
                CarId = car.Id,
                StartDate = start,
                EndDate = start,
                TotalPrice = car.PricePerDay * (end.DayNumber - start.DayNumber)
            };
        }

        // No initial bookings
        yield break;
    }
}