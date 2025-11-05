namespace CarReservation.Web.Data;

internal class RepositoryCollection(DataSource dataSource) : IRepositoryCollection
{
    protected virtual DataSource DataSource { get; } = dataSource;

    public ICitiesRepository Cities()
        => new CitiesRepository(DataSource.Cities);
    public ICarsRepository Cars()
        => new CarsRepository(DataSource.Cars);

    public IBookingsRepository Bookings()
        => new BookingsRepository(DataSource.Bookings);
}

