using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

internal class DataFactory
{
    private const int MinCarsPerCity = 5;
    private const int MaxCarsPerCity = 9;

    public DataSource Init() => Init(Cities().ToList());

    public DataSource Init(IList<City> cities)
        => new()
        {
            Cities = cities,
            Cars = Cars(cities).ToList()
        };

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
        yield return new("", "");
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
                    CityId = cities.ElementAt(random.Next(cities.Count())).Id,
                    Make = carType.Make,
                    Model = carType.Model,
                    LicensePlate = $"{city.Name[..3].ToUpperInvariant()}-{random.Next(100, 9999)}"
                };
            }
        }
    }
}