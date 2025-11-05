using CarReservation.Web.Domain;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace CarReservation.Web.VIewModels;

public partial class BookingItem
{
    /// <summary>
    /// Car identifier
    /// </summary>
    public Guid CarId { get; set; }


    /// <summary>
    /// Name of the vehicle.
    /// </summary>
    public string Name{ get; set; } = string.Empty;

    /// <summary>
    /// License plate of the car
    /// </summary>
    public string LicensePlate { get; set; } = string.Empty;

    /// <summary>
    /// Total price of the booking
    /// </summary>
    public decimal TotalPrice { get; set; }
}
