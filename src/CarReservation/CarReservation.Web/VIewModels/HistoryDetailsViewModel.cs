
using AutoMapper;
using CarReservation.Web.Services;
using Microsoft.AspNetCore.Components;

namespace CarReservation.Web.VIewModels;

public class HistoryDetailsViewModel(IBookingService service, IMapper mapper, NavigationManager navigator) : InitializedViewModelBase(service, mapper, navigator)
{
    protected override Task DoInitializeAsync() => Task.CompletedTask;
}
