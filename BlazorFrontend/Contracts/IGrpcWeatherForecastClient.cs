using Grpc.Core;
using WeatherCommons;

namespace BlazorFrontend.Contracts;

public interface IGrpcWeatherForecastClient
{
    Task<IList<WeatherForecast>> GetWeatherForecasts();
    Task<GetWeatherForecastResponse> GetWeatherForecastsTask();
}