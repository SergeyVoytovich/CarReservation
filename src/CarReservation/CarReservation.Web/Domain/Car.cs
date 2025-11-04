namespace CarReservation.Web.Domain;

/// <summary>
/// Describe car
/// </summary>
public record Car : DomainBase
{
    /// <summary>
    /// Reference to the type
    /// </summary>
    /// <remarks><see cref="CarType"/></remarks>
    public Guid CarTypeId { get; init; }

    /// <summary>
    /// License plate of the car
    /// </summary>
    public string LicensePlate { get; init; } = string.Empty;
}
