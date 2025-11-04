using CarReservation.Web.VIewModels;
using Microsoft.AspNetCore.Components;

namespace CarReservation.Web.Components;

public class ViewBase<T> : ComponentBase where T : ViewModelBase
{
    [Inject]
    public T ViewModel { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        ViewModel.PropertyChanging += (_, e) => StateHasChanged();
        await ViewModel.InitializeAsync();
    }
}
