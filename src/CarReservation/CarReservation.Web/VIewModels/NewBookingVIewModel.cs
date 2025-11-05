using AutoMapper;
using CarReservation.Web.Domain;
using CarReservation.Web.Navigation;
using CarReservation.Web.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using MudBlazor.Extensions;

namespace CarReservation.Web.VIewModels;

public partial class NewBookingViewModel(IBookingService service, IMapper mapper, NavigationManager navigator) : InitializedViewModelBase
{
    protected virtual IBookingService Service { get; } = service;
    protected virtual IMapper Mapper { get; } = mapper;
    protected virtual NavigationManager Navigator { get; } = navigator;


    #region MVVM

    [ObservableProperty]
    private City? city;

    [ObservableProperty]
    private Car? car;

    [ObservableProperty]
    private DateTime? startDate;

    [ObservableProperty]
    private DateTime? endDate;

    [ObservableProperty]
    private decimal totalPrice;

    [ObservableProperty]
    private bool canBook;

    [ObservableProperty]
    private bool isError;

    [ObservableProperty]
    private bool isSuccess;

    [ObservableProperty]
    private bool isBooking;

    [RelayCommand(CanExecute = nameof(CanBook))]
    private Task Book() => BookAsync();

    [RelayCommand]
    private Task Back() => GoBackAsync();

    #endregion


    #region Init

    protected override Task DoInitializeAsync()
    {
        return Task.CompletedTask;
    }

    public virtual Task InitializeAsync(Guid? carId, DateTime? from, DateTime? till)
        => BusyAsync(async () => 
        {
            await TryLoadAsync(carId, from, till);
            IsInitialized = true;
        });

    #endregion


    protected virtual async Task TryLoadAsync(Guid? carId, DateTime? from, DateTime? till)
    {
        if (!carId.HasValue || !from.HasValue || !till.HasValue)
        {
            IsError = true;
            return;
        }

        await LoadAscyn(carId.Value, from.Value, till.Value);
    }

    protected virtual async Task LoadAscyn(Guid carId, DateTime from, DateTime till)
    {
        if(carId == Guid.Empty || from.Date < DateTime.Now.Date || till.Date <= from.Date)
        {
            IsError = true;
            return;
        }

        StartDate = from;
        EndDate = till;

        Car = await Service.GetAvailabilityCarAsync(carId, DateOnly.FromDateTime(from), DateOnly.FromDateTime(till));
        if (Car is null)
        {
            IsError = true;
            return;
        }

        City = await Service.GetCityAsync(Car!.CityId);
        if (City is null)
        {
            IsError = true;
            return;
        }

        
        TotalPrice = Car!.PricePerDay * (decimal)(EndDate!.Value.Date - StartDate!.Value.Date).Days;

        CanBook = true;
    }

    protected virtual Task GoBackAsync()
    {
        var uri = City is null ? UriCollection.Booking.ToRoot(StartDate!.Value, EndDate!.Value)
                               : UriCollection.Booking.ToRoot(City.Id, StartDate!.Value, EndDate!.Value);
        Navigator.NavigateTo(uri);
        return Task.CompletedTask;
    }


    protected virtual async Task BookAsync()
    {
        IsBooking = true;

        
        var result = await Service.BookAsync(Mapper.Map<Booking>(this));

        if (result == BookingResult.Succes)
        {
            CanBook = false;
            IsSuccess = true;
            IsError = false;
        }
        else
        {
            CanBook = true;
            IsSuccess = false;
            IsError = true;
        }

        IsBooking = false;
    }
}
