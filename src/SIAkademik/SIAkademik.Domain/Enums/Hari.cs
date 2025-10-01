namespace SIAkademik.Domain.Enums;

public enum Hari
{
    Senin, Selasa, Rabu, Kamis, Jumat
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
            default: throw new Exception("Invalid hari");
        }
    }
}