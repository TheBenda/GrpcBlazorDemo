using BlazorFrontend.Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Weather;
using WeatherCommons;

namespace BlazorFrontend.Clients;

public class GrpcWeatherForecastClient(WeatherForecasts.WeatherForecastsClient weatherForecastsClient)
    : IGrpcWeatherForecastClient
{
    public Task<GetWeatherForecastResponse> GetWeatherForecastsTask()
    {
        return weatherForecastsClient.GetWeatherForecastAsync(new Empty()).ResponseAsync;
    }
}