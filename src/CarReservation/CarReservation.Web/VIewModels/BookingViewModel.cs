using CarReservation.Web.Domain;
using CarReservation.Web.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;

namespace CarReservation.Web.VIewModels;

public partial class BookingViewModel(IBookingService service) : ViewModelBase
{

    protected virtual IBookingService Service { get; } = service;

    [ObservableProperty]
    private City? city;

    [ObservableProperty]
    private DateTime? startDate;

    [ObservableProperty]
    private DateTime? minStartDate;

    [ObservableProperty]
    private DateTime? minEndDate;

    [ObservableProperty]
    private DateTime? endDate;

    [ObservableProperty]
    private IList<City> cities = [];

    [ObservableProperty]
    private bool isSearching;

    [ObservableProperty]
    private bool canSearch;

    protected override async Task DoInitializeAsync()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        Cities = (await Service.GetCities()).OrderBy(i => i.Name, StringComparer.OrdinalIgnoreCase).ToList();
        StartDate = DateTime.Now.Date;
        MinStartDate = DateTime.Now.Date;
    }

    partial void OnCityChanged(City? value)
    {
        CanSearch = GetCanSearch();
    }

    partial void OnStartDateChanging(DateTime? value)
    {
        CanSearch = GetCanSearch();
    }

    partial void OnStartDateChanged(DateTime? value)
    {
        if (StartDate is null)
        {
            return;
        }

        EndDate = EndDate.HasValue && EndDate.Value.Date > StartDate.Value.Date ? EndDate : StartDate.Value.AddDays(1);
        MinEndDate = EndDate;
        CanSearch = GetCanSearch();
    }

    partial void OnEndDateChanged(DateTime? value) => _ = SearchAsync();


    public bool GetCanSearch()
        => City is not null && StartDate is not null && EndDate is not null && StartDate.Value.Date < EndDate.Value.Date && !IsSearching;

    [RelayCommand(CanExecute = nameof(CanSearch))]
    private async Task SearchAsync()
    {
        if (!GetCanSearch())
        {
            return;
        }

        IsSearching = true;
        CanSearch = false;

        await Task.Delay(TimeSpan.FromMilliseconds(500));
        
        IsSearching = false;
        CanSearch = GetCanSearch();

        SynchronizationContext.Current?.Post(_ =>
        {
            IsSearching = false;
        }, null);

       
    }

}
