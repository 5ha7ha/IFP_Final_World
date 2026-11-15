using TravelTheWorld.Models;

namespace TravelTheWorld.Services;

public interface ISearchService
{
    /// <summary>Finds items whose name, country or description contains the text. A null type means "everything".</summary>
    IReadOnlyList<SearchItem> Search(string? text, ItemType? type);
}
