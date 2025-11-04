namespace CarReservation.Web.Domain;

/// <summary>
/// Represents the association between a city and a car
/// </summary>
public record CityCar : DomainBase
{
    /// <summary>
    /// Reference to the city
    /// </summary>
    /// <remarks><see cref="City"/></remarks>
    public Guid CityId { get; init; }

    /// <summary>
    /// Reference to the car
    /// </summary>
    /// <remarks><see cref="Car"/></remarks>
    public Guid CarId { get; init; }

    /// <summary>
    /// Car reservation price per day
    /// </summary>
    public decimal PricePerDay { get; init; }
}
