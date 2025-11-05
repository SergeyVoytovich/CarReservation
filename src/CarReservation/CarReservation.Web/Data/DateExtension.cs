namespace CarReservation.Web.Data;

public static class DateExtension
{
    public static bool Between(this DateOnly source, DateOnly from, DateOnly till)
        => source >= from && source <= till;
}