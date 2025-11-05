namespace CarReservation.Web.Mapping;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
        => services
            .AddAutoMapper(cnf => cnf.AddProfile<BookingProfile>())
        ;
}
