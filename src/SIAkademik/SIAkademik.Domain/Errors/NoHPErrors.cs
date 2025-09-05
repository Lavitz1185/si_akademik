using SIAkademik.Domain.Shared;

namespace SIAkademik.Domain.Errors;

public static class NoHPErrors
{
    public static readonly Error Empty = new("NoWa.Empty", "No. WA tidak boleh kosong");

    public static readonly Error NotValid = new("NoWa.NotValid", "Nomor WA yang dimasukan tidak valid");

    public static Error InvalidLength(int length) => new("NoWa.InvalidLength", $"Panjang No. WA harus {length}");
}
