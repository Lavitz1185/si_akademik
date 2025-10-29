using AngleSharp;
using SIAkademik.Domain.Services;
using SIAkademik.Domain.Shared;
using SIAkademik.Web.Models;
using System.Text.RegularExpressions;

namespace SIAkademik.Web.Services.HolidayServices;

public class HolidayService : IHolidayService
{
    private readonly HttpClient _httpClient;

    public HolidayService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private static int MonthFromName(string name)
    {
        var match = Regex.Match(name, @"(?<bulan>[a-zA-Z]+)");
        if (!match.Success || !match.Groups.TryGetValue("bulan", out var bulanGroup))
            throw new ArgumentException(nameof(name));

        return Array.FindIndex(CultureInfos.CI.DateTimeFormat.MonthNames, m => m.ToLower() == bulanGroup.Value.ToLower()) + 1;
    }

    private static int[] ParseDay(string day)
    {
        if (int.TryParse(day, out var dayInt)) return [dayInt];

        var match = Regex.Match(day, @"(?<mulai>\d{1,2})-(?<akhir>\d{1,2})");
        if (!match.Success || !match.Groups.TryGetValue("mulai", out var mulaiGroup) || !match.Groups.TryGetValue("akhir", out var akhirGroup))
            throw new ArgumentException(nameof(day));

        var mulai = int.Parse(mulaiGroup.Value);
        var akhir = int.Parse(akhirGroup.Value);
        return Enumerable.Range(mulai, akhir - mulai + 1).ToArray();
    }

    public async Task<Result<List<DateOnly>>> GetHolidays(int year)
    {
        try
        {
            var html = await _httpClient.GetStringAsync($"/{year}");
            if (html is null) return new Error("HolidayService.FetchFailed", "Html is null");

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(req => req.Content(html));
            var months = document.QuerySelectorAll("#main article ul");
            var holidays = months
                .Select(m => new 
                { 
                    bulan = m.QuerySelector("li:first-child a")!, 
                    holidays = m.QuerySelectorAll("li:last-child tr td:first-child") })
                .Where(x => x.holidays.Count() > 0)
                .SelectMany(x => x.holidays
                    .SelectMany(h => ParseDay(h.TextContent).Select(i => new DateOnly(year, MonthFromName(x.bulan.TextContent), i))));

            return holidays.ToList();
        }
        catch(Exception ex)
        {
            return new Error("HolidayService.FetchFailed", $"{ex.Message}");
        }
    }

    public async Task<bool> IsHoliday(DateOnly date)
    {
        var holidays = await GetHolidays(date.Year);

        if (holidays.IsFailure) return false;

        return holidays.Value.Contains(date);
    }
}
