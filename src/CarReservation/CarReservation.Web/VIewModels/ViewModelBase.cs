using AutoMapper;
using CarReservation.Web.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;

namespace CarReservation.Web.VIewModels;

public abstract partial class ViewModelBase(IBookingService service, IMapper mapper, NavigationManager navigator) : ObservableObject
{
    protected virtual IBookingService Service { get; } = service;
    protected virtual IMapper Mapper { get; } = mapper;
    protected virtual NavigationManager Navigator { get; } = navigator;



    [ObservableProperty]
    private bool isBusy = true;

    protected virtual async Task BusyAsync(Func<Task> action)
    {
        IsBusy = true;
        await action.Invoke();
        IsBusy = false;
    }
}