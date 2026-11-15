using System.Net;
using System.Text;
using TravelTheWorld.Models;
using TravelTheWorld.Services;
using TravelTheWorld.Services.Games;
using Xunit;

namespace TravelTheWorld.Tests;

// ---------------------------------------------------------------------------
// QuizEngine
// ---------------------------------------------------------------------------
public class QuizEngineTests
{
    // 2 questions: the correct answer of Q1 is option 1, of Q2 is option 0.
    // new Random(1) = same "random" numbers every run, so the test never changes.
    private static QuizEngine MakeQuiz() => new(new[]
    {
        new QuizQuestion("Spain", "Q1?", new[] { "A", "B", "C", "D" }, 1, "Fact 1"),
        new QuizQuestion("Spain", "Q2?", new[] { "A", "B", "C", "D" }, 0, "Fact 2")
    }, new Random(1));

    // a longer quiz where option 0 is always correct (used to lose all lives)
    private static QuizEngine MakeLongQuiz() => new(
        Enumerable.Range(0, 4)
            .Select(i => new QuizQuestion("X", $"Q{i}", new[] { "A", "B" }, 0, "fact"))
            .ToArray(),
        new Random(1));

    [Fact]
    public void CorrectAnswer_AddsScore_AndKeepsLives()
    {
        var quiz = MakeQuiz();

        quiz.Answer(1);

        Assert.Equal(1, quiz.Score);
        Assert.Equal(QuizEngine.StartLives, quiz.Lives);
        Assert.True(quiz.Answered);
        Assert.Equal("success", quiz.MessageType);
    }

    [Fact]
    public void WrongAnswer_LosesOneLife_AndNoScore()
    {
        var quiz = MakeQuiz();

        quiz.Answer(0);

        Assert.Equal(0, quiz.Score);
        Assert.Equal(QuizEngine.StartLives - 1, quiz.Lives);
        Assert.Equal("error", quiz.MessageType);
    }

    [Fact]
    public void AnsweringTwice_DoesNotChangeScoreOrLives()
    {
        var quiz = MakeQuiz();
        quiz.Answer(1);

        quiz.Answer(0);   // second click on the same question

        Assert.Equal(1, quiz.Score);
        Assert.Equal(QuizEngine.StartLives, quiz.Lives);
        Assert.Equal("info", quiz.MessageType);
    }

    [Fact]
    public void Hint_RemovesTwoWrongOptions_NeverTheCorrectOne()
    {
        var quiz = MakeQuiz();

        quiz.UseHint();

        Assert.Equal(2, quiz.Removed.Count);
        Assert.DoesNotContain(quiz.Current.Correct, quiz.Removed);
        Assert.Equal(0, quiz.Hints);
    }

    [Fact]
    public void Hint_CanOnlyBeUsedOnce()
    {
        var quiz = MakeQuiz();
        quiz.UseHint();

        quiz.UseHint();

        Assert.Equal(2, quiz.Removed.Count);   // nothing more was removed
        Assert.Equal("info", quiz.MessageType);
    }

    [Fact]
    public void Hint_IsNotAllowedAfterAnswering()
    {
        var quiz = MakeQuiz();
        quiz.Answer(1);

        Assert.False(quiz.CanUseHint);
    }

    [Fact]
    public void AnsweringEverythingRight_WinsTheGame()
    {
        var quiz = MakeQuiz();

        quiz.Answer(1);
        quiz.Next();
        quiz.Answer(0);
        quiz.Next();

        Assert.True(quiz.Over);
        Assert.True(quiz.Won);
        Assert.Equal(2, quiz.Score);
        Assert.Equal(100, quiz.Percent);
    }

    [Fact]
    public void ThreeWrongAnswers_EndTheGame()
    {
        var quiz = MakeLongQuiz();

        for (var i = 0; i < 3; i++)
        {
            quiz.Answer(1);   // wrong: the correct option is 0
            if (i < 2) quiz.Next();
        }

        Assert.Equal(0, quiz.Lives);
        Assert.Equal("See result", quiz.NextLabel);

        quiz.Next();

        Assert.True(quiz.Over);
        Assert.False(quiz.Won);
    }

    [Fact]
    public void Restart_ResetsEverything()
    {
        var quiz = MakeQuiz();
        quiz.UseHint();
        quiz.Answer(0);

        quiz.Restart();

        Assert.Equal(0, quiz.Index);
        Assert.Equal(QuizEngine.StartLives, quiz.Lives);
        Assert.Equal(QuizEngine.StartHints, quiz.Hints);
        Assert.Equal(0, quiz.Score);
        Assert.False(quiz.Answered);
        Assert.Empty(quiz.Removed);
    }
}

// ---------------------------------------------------------------------------
// HigherLowerEngine
// ---------------------------------------------------------------------------
public class HigherLowerEngineTests
{
    private static HigherLowerEngine MakeGame(int a, int b) =>
        new(new[] { new PopulationEntry("A", a), new PopulationEntry("B", b) }, new Random(1));

    // the engine decides which country comes first, so we ask it what the right answer is
    private static bool NextIsHigher(HigherLowerEngine game) => game.Next.Million > game.Current.Million;

    [Fact]
    public void RightGuess_AddsToStreakAndBestStreak()
    {
        var game = MakeGame(10, 20);

        game.Guess(NextIsHigher(game));

        Assert.Equal(1, game.Streak);
        Assert.Equal(1, game.BestStreak);
        Assert.Equal(HigherLowerEngine.MaxLives, game.Lives);
    }

    [Fact]
    public void WrongGuess_LosesALife_AndResetsStreak()
    {
        var game = MakeGame(10, 20);

        game.Guess(!NextIsHigher(game));

        Assert.Equal(HigherLowerEngine.MaxLives - 1, game.Lives);
        Assert.Equal(0, game.Streak);
    }

    [Fact]
    public void FiveRightGuesses_GiveStreakOfFive()
    {
        var game = MakeGame(10, 20);

        for (var i = 0; i < 5; i++) game.Guess(NextIsHigher(game));

        Assert.Equal(5, game.Streak);
        Assert.Equal(5, game.BestStreak);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void EqualPopulations_CountAsARightGuess(bool guessHigher)
    {
        var game = MakeGame(10, 10);

        game.Guess(guessHigher);

        Assert.Equal(1, game.Streak);
        Assert.Equal(HigherLowerEngine.MaxLives, game.Lives);
    }

    [Fact]
    public void ThreeWrongGuesses_EndTheGame()
    {
        var game = MakeGame(10, 20);

        for (var i = 0; i < 3; i++) game.Guess(!NextIsHigher(game));

        Assert.True(game.GameOver);
        Assert.Equal(0, game.Lives);
    }

    [Fact]
    public void GuessAfterGameOver_ChangesNothing()
    {
        var game = MakeGame(10, 20);
        for (var i = 0; i < 3; i++) game.Guess(!NextIsHigher(game));

        game.Guess(true);

        Assert.Equal(0, game.Lives);
        Assert.Contains("over", game.Message);
    }

    [Fact]
    public void Restart_KeepsBestStreak_ButResetsLivesAndStreak()
    {
        var game = MakeGame(10, 20);
        game.Guess(NextIsHigher(game));    // right: streak 1
        game.Guess(!NextIsHigher(game));   // wrong: lives 2, streak 0

        game.Restart();

        Assert.Equal(HigherLowerEngine.MaxLives, game.Lives);
        Assert.Equal(0, game.Streak);
        Assert.Equal(1, game.BestStreak);
        Assert.False(game.GameOver);
    }

    [Fact]
    public void NextCountry_IsNeverTheSameAsCurrent()
    {
        for (var i = 0; i < 200; i++)
        {
            var game = new HigherLowerEngine();   // real data, real random
            Assert.NotEqual(game.Current.Name, game.Next.Name);
        }
    }
}

// ---------------------------------------------------------------------------
// TripPlanner (price + form validation)
// ---------------------------------------------------------------------------
public class TripPlannerTests
{
    private static readonly DateTime Today = new(2026, 11, 15);

    [Theory]
    [InlineData("yemen", "budget", 3, 1, 150)]     // 50 x 1   x 3 x 1
    [InlineData("spain", "comfort", 5, 2, 1600)]   // 100 x 1.6 x 5 x 2
    [InlineData("korea", "luxury", 2, 2, 1000)]    // 100 x 2.5 x 2 x 2
    public void CalculateTotal_UsesPriceStyleDaysAndTravelers(
        string country, string style, int days, int travelers, int expected)
    {
        Assert.Equal(expected, TripPlanner.CalculateTotal(country, style, days, travelers));
    }

    [Theory]
    [InlineData("atlantis", "budget", 3, 1)]   // unknown country
    [InlineData("spain", "vip", 3, 1)]         // unknown style
    [InlineData("spain", "budget", 0, 1)]      // no days
    [InlineData("spain", "budget", 3, 0)]      // no travelers
    [InlineData(null, "budget", 3, 1)]         // nothing chosen yet
    [InlineData("spain", null, 3, 1)]
    public void CalculateTotal_ReturnsZero_ForIncompleteOrInvalidInput(
        string? country, string? style, int days, int travelers)
    {
        Assert.Equal(0, TripPlanner.CalculateTotal(country, style, days, travelers));
    }

    [Theory]
    [InlineData("fullName", "", "Please enter your full name.")]
    [InlineData("fullName", "Al", "Name must have at least 3 characters.")]
    [InlineData("fullName", "Aisha123", "Name can contain only letters and spaces.")]
    [InlineData("fullName", "Aisha Karim", "")]
    [InlineData("fullName", "عائشة كريم", "")]          // Arabic letters are allowed
    [InlineData("email", "", "Please enter your email.")]
    [InlineData("email", "name@example", "Enter a valid email, like name@example.com.")]
    [InlineData("email", "name@example.com", "")]
    [InlineData("phone", "", "Please enter your phone number.")]
    [InlineData("phone", "12345", "Use 7 to 15 digits. A + at the start is allowed.")]
    [InlineData("phone", "abc12345678", "Use 7 to 15 digits. A + at the start is allowed.")]
    [InlineData("phone", "+7 701 123 4567", "")]
    [InlineData("destination", "", "Please choose a country.")]
    [InlineData("destination", "spain", "")]
    [InlineData("tripStyle", "", "Please choose a travel style.")]
    [InlineData("tripStyle", "comfort", "")]
    [InlineData("startDate", "", "Please choose a start date.")]
    [InlineData("startDate", "not-a-date", "Please choose a start date.")]
    [InlineData("startDate", "2026-11-15", "The start date must be in the future.")]   // today is not allowed
    [InlineData("startDate", "2026-11-16", "")]                                       // tomorrow is fine
    [InlineData("days", "", "Please enter the number of days.")]
    [InlineData("days", "0", "Days must be a whole number from 1 to 30.")]
    [InlineData("days", "31", "Days must be a whole number from 1 to 30.")]
    [InlineData("days", "2.5", "Days must be a whole number from 1 to 30.")]
    [InlineData("days", "1", "")]
    [InlineData("days", "30", "")]
    [InlineData("travelers", "", "Please enter the number of travelers.")]
    [InlineData("travelers", "11", "Travelers must be a whole number from 1 to 10.")]
    [InlineData("travelers", "10", "")]
    public void Validate_ReturnsTheRightMessage(string field, string value, string expected)
    {
        Assert.Equal(expected, TripPlanner.Validate(field, value, Today));
    }
}

// ---------------------------------------------------------------------------
// Repository data + SearchService (uses the real in-memory data)
// ---------------------------------------------------------------------------
public class DataAndSearchTests
{
    private readonly InMemoryCountryRepository _repo = new();
    private readonly SearchService _search;

    public DataAndSearchTests() => _search = new SearchService(_repo);

    [Fact]
    public void FindCountry_ReturnsCountry_OrNull()
    {
        Assert.NotNull(_repo.FindCountry("spain"));
        Assert.Null(_repo.FindCountry("atlantis"));
        Assert.Null(_repo.FindCountry(null));
    }

    [Fact]
    public void EveryDishAndPlace_BelongsToAnExistingCountry()
    {
        Assert.All(_repo.Dishes.Concat(_repo.Places),
            item => Assert.NotNull(_repo.FindCountry(item.CountryKey)));
    }

    [Fact]
    public void EveryCountry_HasDishesAndPlaces()
    {
        Assert.All(_repo.Countries, c =>
        {
            Assert.NotEmpty(_repo.DishesFor(c.Key));
            Assert.NotEmpty(_repo.PlacesFor(c.Key));
        });
    }

    [Fact]
    public void EveryTripPrice_HasAMatchingCountry()
    {
        Assert.All(TripPlanner.DailyCost.Keys, key => Assert.NotNull(_repo.FindCountry(key)));
    }

    [Fact]
    public void Search_FindsADishByName()
    {
        var results = _search.Search("paella", null);

        Assert.Contains(results, r => r.Name == "Paella" && r.Type == ItemType.Food);
    }

    [Fact]
    public void Search_IgnoresUpperAndLowerCase()
    {
        Assert.Equal(_search.Search("paella", null).Count, _search.Search("PAELLA", null).Count);
    }

    [Fact]
    public void Search_FindsItemsByCountryName()
    {
        var results = _search.Search("Kazakhstan", null);

        Assert.Contains(results, r => r.Name == "Beshbarmak");
    }

    [Fact]
    public void Search_TypeFilter_OnlyReturnsThatType()
    {
        var places = _search.Search("canyon", ItemType.Place);

        Assert.NotEmpty(places);
        Assert.All(places, p => Assert.Equal(ItemType.Place, p.Type));
        Assert.Empty(_search.Search("canyon", ItemType.Food));
    }

    [Fact]
    public void Search_UnknownWord_ReturnsNothing()
    {
        Assert.Empty(_search.Search("zzzzqqq", null));
    }

    [Fact]
    public void Search_WithNoText_ReturnsEverything()
    {
        Assert.Equal(_repo.Dishes.Count + _repo.Places.Count, _search.Search(null, null).Count);
    }
}

// ---------------------------------------------------------------------------
// Weather: code -> text, and the service with a FAKE http answer (no internet)
// ---------------------------------------------------------------------------
public class WeatherTests
{
    [Theory]
    [InlineData(0, "Clear sky")]
    [InlineData(2, "Partly cloudy")]
    [InlineData(45, "Fog")]
    [InlineData(61, "Rain")]
    [InlineData(71, "Snow")]
    [InlineData(80, "Showers")]
    [InlineData(85, "Snow showers")]
    [InlineData(95, "Thunderstorm")]
    public void WeatherCodes_GiveTheRightDescription(int code, string expected)
    {
        Assert.Equal(expected, WeatherCodes.Describe(code).Description);
    }

    // pretends to be the internet: always answers with the JSON we give it
    private sealed class FakeHandler : HttpMessageHandler
    {
        private readonly string _json;
        public string? LastUrl { get; private set; }

        public FakeHandler(string json) => _json = json;

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LastUrl = request.RequestUri!.ToString();
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_json, Encoding.UTF8, "application/json")
            });
        }
    }

    private static OpenMeteoWeatherService MakeService(FakeHandler handler) =>
        new(new HttpClient(handler) { BaseAddress = new Uri("https://api.open-meteo.com/") });

    [Fact]
    public async Task GetCurrentAsync_ReadsTemperatureAndDescription()
    {
        var handler = new FakeHandler("{\"current\":{\"temperature_2m\":21.5,\"weather_code\":0}}");
        var service = MakeService(handler);

        var weather = await service.GetCurrentAsync(15.37, 44.19);

        Assert.NotNull(weather);
        Assert.Equal(21.5, weather!.TemperatureC);
        Assert.Equal("Clear sky", weather.Description);
        Assert.Contains("latitude=15.37", handler.LastUrl);   // dot, never a comma
    }

    [Fact]
    public async Task GetCurrentAsync_ReturnsNull_WhenProviderHasNoData()
    {
        var service = MakeService(new FakeHandler("{}"));

        var weather = await service.GetCurrentAsync(1.1, 2.2);

        Assert.Null(weather);
    }
}