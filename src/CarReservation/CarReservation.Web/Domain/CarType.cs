namespace CarReservation.Web.Domain;

/// <summary>
/// Describe car type
/// </summary>
public record CarType : DomainBase
{
    /// <summary>
    /// Make of the vehicle.
    /// </summary>
    public string Make { get; init; } = string.Empty;

    /// <summary>
    /// Model of the vehicle.
    /// </summary>
    public string Model { get; init; } = string.Empty;
}
