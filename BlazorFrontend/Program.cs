using BlazorFrontend.Clients;
using BlazorFrontend.Components;
using BlazorFrontend.Contracts;
using Grpc.Net.Client.Web;
using Weather;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddGrpcClient<WeatherForecasts.WeatherForecastsClient>(options =>
{
    options.Address = new Uri("http://localhost:5249");
}).ConfigurePrimaryHttpMessageHandler(() => new GrpcWebHandler(new HttpClientHandler()));

builder.Services.AddScoped<IGrpcWeatherForecastClient, GrpcWeatherForecastClient>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();