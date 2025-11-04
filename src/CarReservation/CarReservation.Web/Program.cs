using CarReservation.Web.Components;
using CarReservation.Web.Data;
using CarReservation.Web.Navigation;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();

// Third party
builder.Services.AddMudServices();

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

// Add custim services
builder.Services.AddData();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(UriCollection.Error, createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
