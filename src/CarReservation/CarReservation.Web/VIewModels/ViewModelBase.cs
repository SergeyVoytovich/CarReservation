using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarReservation.Web.VIewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private bool isBusy = true;

    protected virtual async Task BusyAsync(Func<Task> action)
    {
        IsBusy = true;
        await action.Invoke();
        IsBusy = false;
    }
}

public abstract partial class InitializedViewModelBase : ViewModelBase
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
