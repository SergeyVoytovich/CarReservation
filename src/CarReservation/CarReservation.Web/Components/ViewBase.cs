using CarReservation.Web.VIewModels;
using Microsoft.AspNetCore.Components;

namespace CarReservation.Web.Components;

public class ViewBase<T> : ComponentBase where T : InitializedViewModelBase
{
    [Inject]
    public T ViewModel { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if(!firstRender)
        {
            return;
        }

        ViewModel.PropertyChanging += (_, e) =>
        {
            StateHasChanged();
            SynchronizationContext.Current?.Post(_ => StateHasChanged(), null);
        };
        await InitializeViewModelAsync();
    }

    protected virtual Task InitializeViewModelAsync() => ViewModel.InitializeAsync();
}
