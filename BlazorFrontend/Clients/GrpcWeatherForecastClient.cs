using BlazorFrontend.Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcBackend;

namespace BlazorFrontend.Clients;

public class GrpcWeatherForecastClient : IGrpcWeatherForecastClient
{
    private readonly WeatherForecasts.WeatherForecastsClient _weatherForecastsClient;

    public GrpcWeatherForecastClient()
    {
        var grpcChannel = GrpcChannel.ForAddress("http://localhost:5249");
        _weatherForecastsClient = new WeatherForecasts.WeatherForecastsClient(grpcChannel);
    }

    // Note: this is not performant, as double awaits blocks at least 4 threads for what can be done in 2.
    public async Task<IList<WeatherForecast>> GetWeatherForecasts()
    {
        return (await _weatherForecastsClient.GetWeatherForecastAsync(new Empty())).Forecasts;
    }

    public Task<GetWeatherForecastResponse> GetWeatherForecastsTask()
    {
        return _weatherForecastsClient.GetWeatherForecastAsync(new Empty()).ResponseAsync;
    }
}