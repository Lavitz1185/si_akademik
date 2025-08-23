using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Errors;
using SIAkademik.Domain.Shared;
using System.Text.RegularExpressions;

namespace SIAkademik.Domain.ValueObjects;

public class NoHP : ValueObject
{
    public const int ValidLength = 12;
    public const string ValidRegexPattern = @"^08[0-9]+$";

    public string Value { get; }

    private NoHP(string noWa)
    {
        Value = noWa;
    }

    public static Result<NoHP> Create(string noHP)
    {
        if (string.IsNullOrEmpty(noHP))
            return NoHPErrors.Empty;

        if (!Regex.IsMatch(noHP, ValidRegexPattern))
            return NoHPErrors.NotValid;

        if (noHP.Length != ValidLength)
            return NoHPErrors.InvalidLength(ValidLength);

        return new NoHP(noHP);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}