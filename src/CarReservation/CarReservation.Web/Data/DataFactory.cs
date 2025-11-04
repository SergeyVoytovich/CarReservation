using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

internal class DataFactory
{
    private const int MaxCarsPerCity = 7;

    public DataSource Init()
    {
        var cities = Cities().ToList();
        var carTypes = CarTypes().ToList();
        return new DataSource()
        {
            Cities = cities,
            CarTypes = carTypes,
            Cars = Cars(cities, carTypes).ToList()
        };
    }

    private IEnumerable<City> Cities()
    {
        yield return new City { Id = Guid.NewGuid(), Name = "Berlin" };
        yield return new City { Id = Guid.NewGuid(), Name = "Munich" };
        yield return new City { Id = Guid.NewGuid(), Name = "Hamburg" };
        yield return new City { Id = Guid.NewGuid(), Name = "Frankfurt" };
        yield return new City { Id = Guid.NewGuid(), Name = "Stuttgart" };
    }


    private IEnumerable<CarType> CarTypes()
    {
        yield return new CarType { Id = Guid.NewGuid(), Make = "Volkswagen", Model = "Golf" };
        yield return new CarType { Id = Guid.NewGuid(), Make = "BMW", Model = "3 Series" };
        yield return new CarType { Id = Guid.NewGuid(), Make = "Audi", Model = "A4" };
        yield return new CarType { Id = Guid.NewGuid(), Make = "Mercedes-Benz", Model = "C-Class" };
        yield return new CarType { Id = Guid.NewGuid(), Make = "Toyota", Model = "Corolla" };
        yield return new CarType { Id = Guid.NewGuid(), Make = "Ford", Model = "Focus" };
        yield return new CarType { Id = Guid.NewGuid(), Make = "Honda", Model = "Civic" };
        yield return new CarType { Id = Guid.NewGuid(), Make = "Tesla", Model = "Model 3" };
        yield return new CarType { Id = Guid.NewGuid(), Make = "Mazda", Model = "6" };
        yield return new CarType { Id = Guid.NewGuid(), Make = "Škoda", Model = "Octavia" };
    }

    private IEnumerable<Car> Cars(IEnumerable<City> cities, IEnumerable<CarType> carTypes)
    {
        var random = new Random();

        foreach (var city in cities)
        {
            for (int i = 0; i < random.Next(MaxCarsPerCity); i++)
            {
                yield return new Car
                {
                    Id = Guid.NewGuid(),
                    CityId = cities.ElementAt(random.Next(cities.Count())).Id,
                    CarTypeId = carTypes.ElementAt(random.Next(carTypes.Count())).Id,
                    LicensePlate = $"{city.Name[..3].ToUpperInvariant()}-{random.Next(100, 9999)}"
                };
            }
        }
    }
}