using GrpcBackend.Services;
using Persistence.Data;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.AddNpgsqlDbContext<PizzaOrderDbContext>("pizzaorderdb");

builder.Services.AddScoped<IPizzaOrderRepository, PizzaOrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseGrpcWeb();
app.MapGrpcService<WeatherService>().EnableGrpcWeb();
app.MapGrpcReflectionService();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapDefaultEndpoints();
app.Run();