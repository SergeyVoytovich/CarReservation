using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarReservation.Web.VIewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    
}

public abstract partial class InitializedViewModelBase : ViewModelBase
{
    [ObservableProperty]
    private bool isInitialing = true;

    [ObservableProperty]
    private bool isInitialized;

    public async Task InitializeAsync()
    {
        IsInitialing = true;
        await DoInitializeAsync();
        IsInitialing = false;
        IsInitialized = true;
    }

    protected abstract Task DoInitializeAsync();
}
