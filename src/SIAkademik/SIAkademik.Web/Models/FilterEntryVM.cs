namespace SIAkademik.Web.Models;

public class FilterEntryVM<T>
{
    public required T Value { get; set; }
    public required bool Selected {  get; set; }
}

public static class FilterEntryVM
{
    public static List<FilterEntryVM<TEnum>> FromEnum<TEnum>() where TEnum : struct, Enum =>
        [.. Enum.GetValues<TEnum>().Select(e => new FilterEntryVM<TEnum> { Value = e, Selected = false })];
}
