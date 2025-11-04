using CarReservation.Web.Domain;
using System.Data.SqlTypes;

namespace CarReservation.Web.Data;

internal class DataSource
{
    public IList<City> Cities { get; init; } = [];
    public IList<CarType> CarTypes { get; init; } = [];
    public IList<Car> Cars { get; init; } = [];
}
