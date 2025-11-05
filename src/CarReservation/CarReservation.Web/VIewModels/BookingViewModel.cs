using AutoMapper;
using CarReservation.Web.Domain;
using CarReservation.Web.Navigation;
using CarReservation.Web.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;

namespace CarReservation.Web.VIewModels;

public partial class BookingSearchViewModel(IBookingService service, IMapper mapper, NavigationManager navigator) : InitializedViewModelBase
{

    protected virtual IBookingService Service { get; } = service;
    protected virtual IMapper Mapper { get; } = mapper;
    protected virtual NavigationManager Navigator { get; } = navigator;


    #region MVVM

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
    private IList<BookingItem> bookingItems = [];

    [ObservableProperty]
    private bool canSearch;

    [RelayCommand]
    private Task ToSearch() => NavigateToSearchAsync();

    [RelayCommand]
    private void Book(BookingItem item) => BookInternal(item);

    #endregion


    #region Init

    protected override async Task DoInitializeAsync()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        Cities = (await Service.GetCities()).OrderBy(i => i.Name, StringComparer.OrdinalIgnoreCase).ToList();
        StartDate ??= DateTime.Now.Date;
        MinStartDate = DateTime.Now.Date;
    }

    public async Task InitializeAsync(Guid? cityId, DateTime? startDate, DateTime? endDate)
    {
        StartDate = startDate;
        EndDate = endDate;

        if (!IsInitialized)
        {
            await base.InitializeAsync();
        }

        City = cityId.HasValue ? Cities!.SingleOrDefault(i => i.Id == cityId) : null;
        BookingItems = [];

        await SearchAsync();
    }

    #endregion

    partial void OnCityChanged(City? value)
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

    partial void OnEndDateChanged(DateTime? value)
    {
        CanSearch = GetCanSearch();
    }

    public bool GetCanSearch()
        => City is not null && StartDate is not null && EndDate is not null && StartDate.Value.Date < EndDate.Value.Date && !IsSearching;


    public async Task SearchAsync()
    {
        if (!GetCanSearch())
        {
            return;
        }

        IsSearching = true;
        CanSearch = false;

        BookingItems = [];

        await Task.Delay(TimeSpan.FromMilliseconds(500));
        BookingItems = Map(await SearchCarsAsync()).OrderBy(i => i.TotalPrice).ThenBy(i => i.Name).ThenBy(i => i.LicensePlate).ToList();

        IsSearching = false;
        CanSearch = true;
    }

    private Task<IList<Car>> SearchCarsAsync()
        => Service.SearchCarsAsync(City!.Id, DateOnly.FromDateTime(StartDate!.Value), DateOnly.FromDateTime(EndDate!.Value));

    private IList<BookingItem> Map(IList<Car> cars)
        => cars.Select(c => Mapper.Map<Car, BookingItem>(c, opt => opt.AfterMap((src, dst) => CalculateTotalPrice(src, dst)))).ToList();

    private void CalculateTotalPrice(Car source, BookingItem destination)
    {
        destination.TotalPrice = source.PricePerDay * (decimal)(EndDate!.Value.Date - StartDate!.Value.Date).Days;
    }

    protected virtual void BookInternal(BookingItem item)
    {
        Navigator.NavigateTo(UriCollection.Booking.ToNew(item.CarId, StartDate!.Value, EndDate!.Value));
    }

    protected virtual Task NavigateToSearchAsync()
    {
        if (!GetCanSearch())
        {
            return Task.CompletedTask;
        }

        var uri = UriCollection.Booking.ToRoot(City!.Id, StartDate!.Value, EndDate!.Value);

        if(Navigator.Uri.EndsWith(uri, StringComparison.OrdinalIgnoreCase))
        {
            return SearchAsync();
        }

        Navigator.NavigateTo(uri);
        return Task.CompletedTask;
    }
}
