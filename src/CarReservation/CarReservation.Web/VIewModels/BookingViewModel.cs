using AutoMapper;
using CarReservation.Web.Domain;
using CarReservation.Web.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;

namespace CarReservation.Web.VIewModels;

public partial class BookingViewModel(IBookingService service, IMapper mapper) : InitializedViewModelBase
{

    protected virtual IBookingService Service { get; } = service;
    protected virtual IMapper Mapper { get; } = mapper;

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

    [ObservableProperty]
    private IList<BookingItemViewModel> bookingItems = [];

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
        BookingItems = Map(await SearchCarsAsync()).OrderBy(i => i.TotalPrice).ThenBy(i => i.Name).ThenBy(i => i.LicensePlate).ToList();
        
        IsSearching = false;
        CanSearch = GetCanSearch();
    }

    private Task<IList<Car>> SearchCarsAsync()
        => Service.SearchCarsAsync(City!.Id, DateOnly.FromDateTime(StartDate!.Value), DateOnly.FromDateTime(EndDate!.Value));

    private IList<BookingItemViewModel> Map(IList<Car> cars)
        => cars.Select(c => Mapper.Map<Car, BookingItemViewModel>(c, opt => opt.AfterMap((src, dst) => CalculateTotalPrice(src, dst)))).ToList();

    private void CalculateTotalPrice(Car source, BookingItemViewModel destination )
    {
        destination.TotalPrice = source.PricePerDay * (decimal)(EndDate!.Value.Date - StartDate!.Value.Date).Days;
    }

}
