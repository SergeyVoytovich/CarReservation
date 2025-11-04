using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarReservation.Web.VIewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private bool isInitialing = true;

    public async Task InitializeAsync()
    {
        IsInitialing = true;
        await DoInitializeAsync();
        IsInitialing = false;
    }

    protected abstract Task DoInitializeAsync();
}
