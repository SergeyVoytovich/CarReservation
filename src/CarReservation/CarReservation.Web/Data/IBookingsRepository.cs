using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

/// <summary>
/// Repository for work with bookings.
/// </summary>
public interface IBookingsRepository : IRepository<Booking>
{
    /// <summary>
    /// Get booking for a scespecific cars in specific date interval
    /// </summary>
    /// <param name="carIds">Cars identifiers</param>
    /// <param name="from">From date</param>
    /// <param name="till">Till date</param>
    /// <returns>List of <see href="Booking"></returns>
    Task<IList<Booking>> GetAsync(IList<Guid> carsIds, DateOnly from, DateOnly till);

    /// <summary>
    /// Add new entry about booking
    /// </summary>
    /// <param name="booking">Booking</param>
    /// <returns>Task</returns>
    Task AddAsync(Booking booking);
}