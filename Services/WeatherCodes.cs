namespace TravelTheWorld.Services;

/// <summary>Turns the weather code from the API into an icon and a text (port of describe() in weather.js).</summary>
public static class WeatherCodes
{
    public static (string Icon, string Description) Describe(int code) => code switch
    {
        0 => ("☀️", "Clear sky"),
        <= 3 => ("⛅", "Partly cloudy"),
        <= 48 => ("🌫️", "Fog"),
        <= 67 => ("🌧️", "Rain"),
        <= 77 => ("❄️", "Snow"),
        <= 82 => ("🌦️", "Showers"),
        <= 86 => ("🌨️", "Snow showers"),
        _ => ("⛈️", "Thunderstorm")
    };
}