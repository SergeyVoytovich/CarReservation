using CarReservation.Web.Domain;
using CarReservation.Web.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarReservation.Web.VIewModels;

public partial class BookingViewModel(IBookingService service) : ViewModelBase
{

    protected virtual IBookingService Service { get; } = service;

    [ObservableProperty]
    private City? city;

    [ObservableProperty]
    private DateOnly startDate = DateOnly.FromDateTime(DateTime.Now);

    [ObservableProperty]
    private DateOnly endDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));


    [ObservableProperty]
    private IList<City> cities = [];

    protected override async Task DoInitializeAsync()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        Cities = (await Service.GetCities()).OrderBy(i => i.Name, StringComparer.OrdinalIgnoreCase).ToList();
    }
}
