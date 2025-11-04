using CarReservation.Web.Domain;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarReservation.Web.VIewModels;

public partial class BookingViewModel : ViewModelBase
{

    [ObservableProperty]
    private City? city;

    [ObservableProperty]
    private DateOnly startDate = DateOnly.FromDateTime(DateTime.Now);

    [ObservableProperty]
    private DateOnly endDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));


    [ObservableProperty]
    private IList<City> cities = [];

    protected override Task DoInitializeAsync()
    {
        return Task.Delay(TimeSpan.FromSeconds(1));
    }
}
