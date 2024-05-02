using GrcpBackend;
using GrcpBackend.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

// builder.WebHost.ConfigureKestrel(options =>
// {
//     // Setup a HTTP/2 endpoint without TLS.
//     options.ListenAnyIP(5249, o => o.Protocols = HttpProtocols.Http2);
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseGrpcWeb();
app.MapGrpcService<GreeterService>();
app.MapGrpcService<WeatherService>().EnableGrpcWeb();
app.MapGrpcReflectionService();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();