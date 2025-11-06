using AutoMapper;
using CarReservation.Web.Domain;
using CarReservation.Web.Navigation;
using CarReservation.Web.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices.Marshalling;

namespace CarReservation.Web.VIewModels;

public partial class HistoryViewModel(IBookingService service, IMapper mapper, NavigationManager navigator)
    : InitializedViewModelBase(service, mapper, navigator)
{
    #region MVVM

    [ObservableProperty]
    private IList<HistoryItem> items = [];

    [RelayCommand]
    private Task Detailw(HistoryItem item) => GoToDetailsAsync(item);

    #endregion


    protected override async Task DoInitializeAsync()
    {
        var bookings = await Service.GetBookingsAsync();
        var cars = await Service.GetCarsAsync(bookings);
        var cities = await Service.GetCitiesAsync(cars);

        Items = bookings
            .Select(i => Map(i, cars, cities))
            .OrderBy(i => i.Booking.StartDate)
            .ThenBy(i => i.City.Name)
            .ThenBy(i => i.Car.Make)
            .ThenBy(i => i.Car.Model)
            .ThenBy(i => i.Car.LicensePlate)
            .ToList();
    }

    protected virtual HistoryItem Map(Booking booking, IEnumerable<Car> cars, IEnumerable<City> cities)
    {
        var historyItem = new HistoryItem
        {
            Booking = booking,
            Car = cars.ById(booking.CarId).Single(),
        };
        historyItem.City = cities.ById(historyItem.Car.CityId).Single();
        return historyItem;
    }

    protected virtual Task GoToDetailsAsync(HistoryItem item)
    {
        Navigator.NavigateTo(UriCollection.History.ToDetails(item.Booking.Id));
        return Task.CompletedTask;
    }
}

