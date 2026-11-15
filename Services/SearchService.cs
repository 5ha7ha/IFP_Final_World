using TravelTheWorld.Models;

namespace TravelTheWorld.Services;

/// <summary>Port of search.js: one combined list of dishes and places, filtered by text and type.</summary>
public sealed class SearchService : ISearchService
{
    private readonly IReadOnlyList<SearchItem> _items;

    public SearchService(ICountryRepository repository)
    {
        _items = repository.Dishes.Select(d => ToItem(repository, ItemType.Food, d))
            .Concat(repository.Places.Select(p => ToItem(repository, ItemType.Place, p)))
            .ToList();
    }

    public IReadOnlyList<SearchItem> Search(string? text, ItemType? type)
    {
        var term = text?.Trim() ?? string.Empty;

        return _items
            .Where(i => type is null || i.Type == type)
            .Where(i => $"{i.Name} {i.Description} {i.Country.Name}"
                .Contains(term, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    private static SearchItem ToItem(ICountryRepository repository, ItemType type, ContentItem content)
    {
        var country = repository.FindCountry(content.CountryKey)
            ?? throw new InvalidOperationException($"Unknown country key '{content.CountryKey}'.");
        return new SearchItem(type, content.Name, content.Description, content.Image, country);
    }
}