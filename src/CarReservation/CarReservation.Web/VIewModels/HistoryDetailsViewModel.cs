
using AutoMapper;
using CarReservation.Web.Domain;
using CarReservation.Web.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;

namespace CarReservation.Web.VIewModels;

public partial class HistoryDetailsViewModel(IBookingService service, IMapper mapper, NavigationManager navigator)
    : InitializedViewModelBase(service, mapper, navigator)
{

    public Booking Booking { get; set; } = new();
    public City City { get; set; } = new();
    public Car Car { get; set; } = new();


    #region MVVM

    [ObservableProperty]
    private bool isError;

    [RelayCommand]
    private Task Back() => Task.CompletedTask;

    #endregion



    #region Init

    protected override Task DoInitializeAsync() => Task.CompletedTask;

    public virtual Task InitializeAsync(Guid? id)
        => BusyAsync(async () => 
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        });

    #endregion



}
