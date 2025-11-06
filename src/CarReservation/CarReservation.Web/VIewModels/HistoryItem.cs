using CarReservation.Web.Domain;

namespace CarReservation.Web.VIewModels;

public class HistoryItem
{
    public Booking Booking { get; set; } = new();
    public City City { get; set; } = new();
    public Car Car { get; set; } = new();
}
