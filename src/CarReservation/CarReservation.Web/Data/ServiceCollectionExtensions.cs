namespace CarReservation.Web.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
        => services
            .AddSingleton<DataFactory>()
            .AddSingleton<DataSource>(p => p.GetRequiredService<DataFactory>().Init())
        ;
}
