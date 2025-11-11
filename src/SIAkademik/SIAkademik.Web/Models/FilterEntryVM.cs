namespace SIAkademik.Web.Models;

public class FilterEntryVM<T>
{
    public required T Value { get; set; }
    public required bool Selected {  get; set; }
}

public static class FilterEntryVM
{
    public static List<FilterEntryVM<TEnum>> FromEnum<TEnum>(IEnumerable<TEnum> selected) where TEnum : struct, Enum =>
        [.. Enum.GetValues<TEnum>().Select(e => new FilterEntryVM<TEnum> { Value = e, Selected = selected.Contains(e) })];

    public static List<FilterEntryVM<T>> ToFilterEntryList<T>(this IEnumerable<T> values, List<T> selected) =>
        values.Select(v => new FilterEntryVM<T> { Value = v, Selected = selected.Contains(v) }).ToList();

    public static List<T> Selected<T>(this IEnumerable<FilterEntryVM<T>> values) => values.Where(v => v.Selected).Select(v => v.Value).ToList();
}
