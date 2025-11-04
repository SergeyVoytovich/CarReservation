namespace CarReservation.Web.Domain;

/// <summary>
/// Describe car type
/// </summary>
public record CarType : DomainBase
{
    /// <summary>
    /// URL of the preview image
    /// </summary>
    public string ImageUrl { get; init; } = string.Empty;

    /// <summary>
    /// Make of the vehicle.
    /// </summary>
    public string Make { get; init; } = string.Empty;

    /// <summary>
    /// Model of the vehicle.
    /// </summary>
    public string Model { get; init; } = string.Empty;
}
