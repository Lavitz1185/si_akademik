using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIAkademik.Domain.ValueObjects;

namespace SIAkademik.Infrastructure.Database.ValueConverters;

internal class NoHPIntConverter : ValueConverter<NoHP, string>
{
    public NoHPIntConverter() :
        base(n => n.Value, s => NoHP.Create(s).Value)
    { }
}
