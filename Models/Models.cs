namespace TravelTheWorld.Models;

public sealed record WeatherLocation(string Name, double Latitude, double Longitude);

public sealed record WeatherInfo(double TemperatureC, string Icon, string Description);

public sealed record Fact(string Label, string Value);

public sealed record CountryQuote(string Text, string Lang, string Dir);

/// <summary>One country (replaces an object of the `countries` array in data.js).</summary>
public sealed record Country
{
    public required string Key { get; init; }
    public required string Name { get; init; }
    public required string Capital { get; init; }
    public required string[] Languages { get; init; }
    public required string Currency { get; init; }
    public required int Population { get; init; }
    public required string Flag { get; init; }
    public required string Map { get; init; }
    public required string Accent { get; init; }
    public required string HeroBg { get; init; }
    public required string HeroGlow { get; init; }
    public required CountryQuote Quote { get; init; }
    public required string[] Facts { get; init; }

    /// <summary>Replaces "country.html?c=spain".</summary>
    public string Page => $"country?c={Key}";
}

/// <summary>A dish or a place (same shape in data.js, so one record is enough).</summary>
public sealed record ContentItem(string CountryKey, string Name, string Description, string Image);

public enum ItemType
{
    Food,
    Place
}

/// <summary>One entry of the combined search list (searchItems in search.js).</summary>
public sealed record SearchItem(ItemType Type, string Name, string Description, string Image, Country Country);
