namespace CarReservation.Web.Domain;

/// <summary>
/// Describe car
/// </summary>
public record Car : DomainBase
{
    /// <summary>
    /// Reference to the city
    /// </summary>
    /// <remarks><see cref="City"/></remarks>
    public Guid CityId { get; init; }

    /// <summary>
    /// Make of the vehicle.
    /// </summary>
    public string Make { get; init; } = string.Empty;

    /// <summary>
    /// Model of the vehicle.
    /// </summary>
    public string Model { get; init; } = string.Empty;

    /// <summary>
    /// License plate of the car
    /// </summary>
    public string LicensePlate { get; init; } = string.Empty;

    /// <summary>
    /// Car reservation price per day
    /// </summary>
    public decimal PricePerDay { get; init; }

}
