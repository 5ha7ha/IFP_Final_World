namespace TravelTheWorld.Services.Games;

/// <summary>The rules of the Higher or Lower game (port of game.js). No UI code in here, so it is easy to test.</summary>
public sealed class HigherLowerEngine
{
    public const int MaxLives = 3;

    private readonly IReadOnlyList<PopulationEntry> _entries;
    private readonly Random _random;
    private int _currentIndex;
    private int _nextIndex;

    public HigherLowerEngine(IReadOnlyList<PopulationEntry>? entries = null, Random? random = null)
    {
        _entries = entries ?? PopulationData.All;
        _random = random ?? Random.Shared;
        Restart();
    }

    public int Lives { get; private set; }
    public int Streak { get; private set; }
    public int BestStreak { get; private set; }
    public bool GameOver { get; private set; }
    public string Message { get; private set; } = "";
    public string MessageClass { get; private set; } = "game-message";

    public PopulationEntry Current => _entries[_currentIndex];
    public PopulationEntry Next => _entries[_nextIndex];

    public string Question => GameOver
        ? "Game over!"
        : $"Does {Next.Name} have a higher or lower population than {Current.Name}?";

    public void Restart()
    {
        Lives = MaxLives;
        Streak = 0;
        GameOver = false;
        _currentIndex = _random.Next(_entries.Count);
        PickNext();
        Message = "";
        MessageClass = "game-message";
    }

    // the next country must not be the same as the current one
    private void PickNext()
    {
        do { _nextIndex = _random.Next(_entries.Count); }
        while (_nextIndex == _currentIndex);
    }

    public void Guess(bool higher)
    {
        // invalid move: show a message and change nothing
        if (GameOver)
        {
            Message = "The game is over. Press Restart to play again.";
            MessageClass = "game-message wrong";
            return;
        }

        var current = Current;
        var next = Next;

        // equal values count as a right guess
        var isRight = higher ? next.Million >= current.Million : next.Million <= current.Million;
        var info = $"{next.Name} has {next.Million} million.";

        if (isRight)
        {
            Streak++;
            if (Streak > BestStreak) BestStreak = Streak;
            Message = "Correct! " + info;
            MessageClass = "game-message correct";
        }
        else
        {
            Lives--;
            Streak = 0;
            Message = "Wrong! " + info;
            MessageClass = "game-message wrong";
            if (Lives == 0)
            {
                GameOver = true;
                Message += " No lives left.";
            }
        }

        // if the game goes on, the next country becomes the current one
        if (!GameOver)
        {
            _currentIndex = _nextIndex;
            PickNext();
        }
    }
}