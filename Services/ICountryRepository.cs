using TravelTheWorld.Models;

namespace TravelTheWorld.Services;

public interface ICountryRepository
{
    IReadOnlyList<Country> Countries { get; }
    IReadOnlyList<ContentItem> Dishes { get; }
    IReadOnlyList<ContentItem> Places { get; }

    /// <summary>Returns null when there is no such country (same as findCountry in country.js).</summary>
    Country? FindCountry(string? key);

    IReadOnlyList<ContentItem> DishesFor(string countryKey);
    IReadOnlyList<ContentItem> PlacesFor(string countryKey);
}