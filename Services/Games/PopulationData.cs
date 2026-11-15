namespace TravelTheWorld.Services.Games;

/// <summary>Population in millions (approximate).</summary>
public sealed record PopulationEntry(string Name, int Million);

public static class PopulationData
{
    public static readonly IReadOnlyList<PopulationEntry> All = new PopulationEntry[]
    {
        new("India", 1430), new("China", 1410), new("USA", 340), new("Indonesia", 278),
        new("Pakistan", 245), new("Nigeria", 224), new("Brazil", 217), new("Bangladesh", 173),
        new("Russia", 144), new("Mexico", 128), new("Ethiopia", 126), new("Japan", 124),
        new("Philippines", 117), new("Egypt", 112), new("DR Congo", 105), new("Vietnam", 100),
        new("Iran", 89), new("Turkey", 85), new("Germany", 84), new("Thailand", 72),
        new("United Kingdom", 68), new("France", 68), new("Tanzania", 67), new("South Africa", 60),
        new("Italy", 59), new("Kenya", 54), new("Myanmar", 54), new("South Korea", 52),
        new("Colombia", 52), new("Spain", 48), new("Uganda", 48), new("Sudan", 48),
        new("Argentina", 46), new("Algeria", 46), new("Iraq", 45), new("Afghanistan", 42),
        new("Canada", 40), new("Poland", 38), new("Morocco", 38), new("Ukraine", 37),
        new("Saudi Arabia", 36), new("Uzbekistan", 36), new("Peru", 34), new("Malaysia", 34),
        new("Yemen", 34), new("Ghana", 34), new("Nepal", 30), new("Madagascar", 30),
        new("Venezuela", 28), new("Australia", 26), new("Sri Lanka", 22), new("Kazakhstan", 20),
        new("Chile", 20), new("Netherlands", 18)
    };
}