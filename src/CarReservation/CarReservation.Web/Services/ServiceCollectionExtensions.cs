namespace CarReservation.Web.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddScoped<IBookingService, BookingService>()
            ;
}
