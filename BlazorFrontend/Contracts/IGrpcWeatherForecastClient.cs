using Grpc.Core;
using GrpcBackend;

namespace BlazorFrontend.Contracts;

public interface IGrpcWeatherForecastClient
{
    Task<IList<WeatherForecast>> GetWeatherForecasts();
    Task<GetWeatherForecastResponse> GetWeatherForecastsTask();
}