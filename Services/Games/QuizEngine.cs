namespace TravelTheWorld.Services.Games;

/// <summary>The rules of the quiz (port of quiz.js). No UI code in here, so it is easy to test.</summary>
public sealed class QuizEngine
{
    public const int StartLives = 3;
    public const int StartHints = 1;       // for the 50/50 hint
    public const int WrongToRemove = 2;    // how many wrong answers 50/50 removes

    private readonly IReadOnlyList<QuizQuestion> _questions;
    private readonly Random _random;
    private readonly List<int> _removed = new();

    public QuizEngine(IReadOnlyList<QuizQuestion>? questions = null, Random? random = null)
    {
        _questions = questions ?? QuizData.Questions;
        _random = random ?? Random.Shared;
        Restart();
    }

    public IReadOnlyList<QuizQuestion> Questions => _questions;
    public int Index { get; private set; }
    public int Lives { get; private set; }
    public int Score { get; private set; }
    public int Hints { get; private set; }
    public bool Answered { get; private set; }
    public int? Chosen { get; private set; }
    public bool Over { get; private set; }
    public bool Won { get; private set; }
    public string Message { get; private set; } = "";
    public string MessageType { get; private set; } = "";   // "success", "error", "info" or ""

    /// <summary>Options removed by 50/50 on this question.</summary>
    public IReadOnlyList<int> Removed => _removed;

    public QuizQuestion Current => _questions[Index];
    public bool IsLast => Index == _questions.Count - 1;
    public bool CanUseHint => Hints > 0 && !Answered && _removed.Count == 0;
    public string NextLabel => (IsLast || Lives == 0) ? "See result" : "Next question";

    // calculated value: percentage of correct answers
    public int Percent => (int)Math.Round(Score * 100.0 / _questions.Count, MidpointRounding.AwayFromZero);

    public void Restart()
    {
        Index = 0;
        Lives = StartLives;
        Score = 0;
        Hints = StartHints;
        Answered = false;
        Chosen = null;
        _removed.Clear();
        Over = false;
        Won = false;
        Say("", "");
    }

    private void Say(string text, string type)
    {
        Message = text;
        MessageType = type;
    }

    public void Answer(int option)
    {
        // invalid move: show a message, do NOT change the game
        if (Answered)
        {
            Say("You already answered. Press the button to continue.", "info");
            return;
        }

        Answered = true;
        Chosen = option;

        if (option == Current.Correct)
        {
            Score++;
            Say("Correct! " + Current.Fact, "success");
        }
        else
        {
            Lives--;
            Say("Wrong answer. The correct one is highlighted. " + Current.Fact, "error");
        }
    }

    public void UseHint()
    {
        // invalid move: show a message and do NOT change the game
        if (!CanUseHint)
        {
            Say("You can't use 50/50 now.", "info");
            return;
        }

        var wrong = Enumerable.Range(0, Current.Options.Length).Where(i => i != Current.Correct).ToList();

        // remove random wrong options
        for (var n = 0; n < WrongToRemove && wrong.Count > 0; n++)
        {
            var r = _random.Next(wrong.Count);
            _removed.Add(wrong[r]);
            wrong.RemoveAt(r);
        }

        Hints--;
        Say("50/50 used: wrong answers removed.", "info");
    }

    public void Next()
    {
        if (Lives == 0)
        {
            Over = true;
            Won = false;
        }
        else if (IsLast)
        {
            Over = true;
            Won = true;
        }
        else
        {
            Index++;
            Answered = false;
            Chosen = null;
            _removed.Clear();
            Say("", "");
        }
    }
}