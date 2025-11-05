using AutoMapper;
using CarReservation.Web.Domain;
using CarReservation.Web.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;

namespace CarReservation.Web.VIewModels;

public class NewBookingVIewModel(IBookingService service, IMapper mapper, NavigationManager navigator) : InitializedViewModelBase
{

    #region MVVM

    [ObservableProperty]
    private City? city;

    [ObservableProperty]
    private DateTime? startDate;

    [ObservableProperty]
    private DateTime? endDate;

    [ObservableProperty]
    private IList<City> cities = [];

    [ObservableProperty]
    private decimal totalPrice;

    [ObservableProperty]
    private IList<BookingItem> bookingItems = [];

    [ObservableProperty]
    private bool canSearch;


    [RelayCommand]
    private void Book(BookingItem item) { };

    #endregion


    #region Init

    protected override Task DoInitializeAsync()
    {
        throw new NotImplementedException();
    }

    #endregion
}
