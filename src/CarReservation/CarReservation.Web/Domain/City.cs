using Microsoft.AspNetCore.SignalR.Protocol;

namespace CarReservation.Web.Domain;

/// <summary>
/// Describe city
/// </summary>
public record City : DomainBase
{
    /// <summary>
    /// Name of the city
    /// </summary>
    public string Name { get; init; } = string.Empty;
}