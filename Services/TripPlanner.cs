using System.Globalization;
using System.Text.RegularExpressions;

namespace TravelTheWorld.Services;

public sealed record TravelStyle(string Key, string Name, double Multiplier);

public static class TripPlanner
{
    /// <summary>Price per person per day in US dollars (Budget style), by country key.
    /// Only countries listed here can be chosen on the Plan page. Add a line to offer another country.</summary>
    public static readonly IReadOnlyDictionary<string, int> DailyCost = new Dictionary<string, int>
    {
        ["yemen"] = 50,
        ["spain"] = 110,
        ["kazakhstan"] = 70,
        ["korea"] = 100
    };

    public static readonly IReadOnlyList<TravelStyle> Styles = new TravelStyle[]
    {
        new("budget", "Budget", 1),
        new("comfort", "Comfort", 1.6),
        new("luxury", "Luxury", 2.5)
    };

    public static readonly string[] FieldNames =
    {
        "fullName", "email", "phone", "destination", "tripStyle", "startDate", "days", "travelers"
    };

    public static TravelStyle? FindStyle(string? key) => Styles.FirstOrDefault(s => s.Key == key);

    public static int CalculateTotal(string? destinationKey, string? styleKey, int days, int travelers)
    {
        var style = FindStyle(styleKey);
        if (destinationKey is null || style is null || days < 1 || travelers < 1
            || !DailyCost.TryGetValue(destinationKey, out var daily))
        {
            return 0;
        }
        return (int)Math.Round(daily * style.Multiplier * days * travelers, MidpointRounding.AwayFromZero);
    }

    // ===== VALIDATION RULES =====
    private static readonly Regex NameRx = new(@"^[A-Za-z\u00C0-\u024F\u0400-\u04FF\u0600-\u06FF' -]+$");
    private static readonly Regex EmailRx = new(@"^[^\s@]+@[^\s@]+\.[^\s@]{2,}$");
    private static readonly Regex PhoneRx = new(@"^\+?[0-9\s\-()]+$");

    /// <summary>Returns an error text, or "" when the value is correct.</summary>
    public static string Validate(string field, string? rawValue, DateTime today)
    {
        var value = rawValue ?? "";
        var trimmed = value.Trim();

        switch (field)
        {
            case "fullName":
                if (trimmed == "") return "Please enter your full name.";
                if (trimmed.Length < 3) return "Name must have at least 3 characters.";
                if (!NameRx.IsMatch(trimmed)) return "Name can contain only letters and spaces.";
                return "";

            case "email":
                if (trimmed == "") return "Please enter your email.";
                if (!EmailRx.IsMatch(trimmed)) return "Enter a valid email, like name@example.com.";
                return "";

            case "phone":
                if (trimmed == "") return "Please enter your phone number.";
                var digits = Regex.Replace(value, @"\D", "").Length;
                if (!PhoneRx.IsMatch(trimmed) || digits < 7 || digits > 15)
                    return "Use 7 to 15 digits. A + at the start is allowed.";
                return "";

            case "destination":
                return value == "" ? "Please choose a country." : "";

            case "tripStyle":
                return value == "" ? "Please choose a travel style." : "";

            case "startDate":
                if (value == "") return "Please choose a start date.";
                if (!DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out var date))
                    return "Please choose a start date.";
                if (date.Date <= today.Date) return "The start date must be in the future.";
                return "";

            case "days":
                if (value == "") return "Please enter the number of days.";
                return WholeNumberInRange(value, 1, 30) ? "" : "Days must be a whole number from 1 to 30.";

            case "travelers":
                if (value == "") return "Please enter the number of travelers.";
                return WholeNumberInRange(value, 1, 10) ? "" : "Travelers must be a whole number from 1 to 10.";

            default:
                return "";
        }
    }

    private static bool WholeNumberInRange(string value, int min, int max) =>
        int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var n) && n >= min && n <= max;
}