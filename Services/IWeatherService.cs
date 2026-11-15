using TravelTheWorld.Models;

namespace TravelTheWorld.Services;

public interface IWeatherService
{
    /// <summary>Returns the current weather, or null if the provider had no data.</summary>
    Task<WeatherInfo?> GetCurrentAsync(double latitude, double longitude, CancellationToken cancellationToken = default);
}
