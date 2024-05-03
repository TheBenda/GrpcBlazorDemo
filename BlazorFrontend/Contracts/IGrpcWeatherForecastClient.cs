using Grpc.Core;
using WeatherCommons;

namespace BlazorFrontend.Contracts;

public interface IGrpcWeatherForecastClient
{
    Task<GetWeatherForecastResponse> GetWeatherForecastsTask();
}