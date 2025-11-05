namespace CarReservation.Web.Domain;

/// <summary>
/// Describe booking
/// </summary>
public record Booking : DomainBase
{
    /// <summary>
    /// Reference to the car
    /// </summary>
    /// <remarks><see cref="Car"/></remarks>
    public Guid CarId { get; init; }

    /// <summary>
    /// State date of the booking
    /// </summary>
    public DateOnly StartDate { get; init; }

    /// <summary>
    /// End date of the booking
    /// </summary>
    public DateOnly EndDate { get; init; }

    /// <summary>
    /// Total price of the booking
    /// </summary>
    public decimal TotalPrice { get; init; }
}