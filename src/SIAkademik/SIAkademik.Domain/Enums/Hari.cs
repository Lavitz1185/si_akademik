namespace SIAkademik.Domain.Enums;

public enum Hari
{
    Senin, Selasa, Rabu, Kamis, Jumat, Sabtu, Minggu
}

public static class HariExtension
{
    public static DayOfWeek FromHari(this Hari hari)
    {
        switch (hari)
        {
            case Hari.Senin: return DayOfWeek.Monday;
            case Hari.Selasa: return DayOfWeek.Tuesday;
            case Hari.Rabu: return DayOfWeek.Wednesday;
            case Hari.Kamis: return DayOfWeek.Thursday;
            case Hari.Jumat: return DayOfWeek.Friday;
            case Hari.Sabtu: return DayOfWeek.Saturday;
            case Hari.Minggu: return DayOfWeek.Sunday;
            default: throw new Exception("Invalid hari");
        }
    }
}