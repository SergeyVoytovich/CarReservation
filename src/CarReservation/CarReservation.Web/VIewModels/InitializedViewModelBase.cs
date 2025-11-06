using AutoMapper;
using CarReservation.Web.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;

namespace CarReservation.Web.VIewModels;

public abstract partial class InitializedViewModelBase(IBookingService service, IMapper mapper, NavigationManager navigator) 
    : ViewModelBase(service, mapper, navigator)
{
    [ObservableProperty]
    private bool isInitialized;

    public Task InitializeAsync()
        => BusyAsync(async () =>
        {
            await DoInitializeAsync();
            IsInitialized = true;
        });

    protected abstract Task DoInitializeAsync();
}
