using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TravelTheWorld.Models;

namespace TravelTheWorld.Services;

public sealed class OpenMeteoWeatherService : IWeatherService
{
    private readonly HttpClient _http;

    public OpenMeteoWeatherService(HttpClient http) => _http = http;

    public async Task<WeatherInfo?> GetCurrentAsync(
        double latitude, double longitude, CancellationToken cancellationToken = default)
    {
        // FormattableString.Invariant guarantees "15.37", never "15,37", whatever the browser locale is.
        var url = FormattableString.Invariant(
            $"v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,weather_code");

        var response = await _http.GetFromJsonAsync<OpenMeteoResponse>(url, cancellationToken);
        if (response?.Current is null)
        {
            return null;
        }

        var (icon, description) = WeatherCodes.Describe(response.Current.WeatherCode);
        return new WeatherInfo(response.Current.Temperature, icon, description);
    }

    // Shape of the part of the Open-Meteo response we use.
    private sealed class OpenMeteoResponse
    {
        [JsonPropertyName("current")]
        public CurrentBlock? Current { get; set; }
    }

    private sealed class CurrentBlock
    {
        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }
    }
}
