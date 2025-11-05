using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarReservation.Web.VIewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private bool isBusy = true;
}

public abstract partial class InitializedViewModelBase : ViewModelBase
{
    [ObservableProperty]
    private bool isInitialized;

    public async Task InitializeAsync()
    {
        IsBusy = true;
        await DoInitializeAsync();
        IsBusy = false;
        IsInitialized = true;
    }

    protected abstract Task DoInitializeAsync();
}
