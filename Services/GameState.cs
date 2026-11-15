using TravelTheWorld.Services.Games;

namespace TravelTheWorld.Services;

/// <summary>Keeps the games alive while the user moves between pages.</summary>
public sealed class GameState
{
    public HigherLowerEngine HigherLower { get; } = new();
    public QuizEngine Quiz { get; } = new();
}