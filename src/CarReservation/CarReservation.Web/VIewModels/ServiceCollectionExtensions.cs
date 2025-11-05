namespace CarReservation.Web.VIewModels;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
        => services
            .AddTransient<BookingSearchViewModel>()
            .AddTransient<NewBookingViewModel>()
        ;
}
