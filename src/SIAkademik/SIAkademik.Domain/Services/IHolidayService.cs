using SIAkademik.Domain.Shared;

namespace SIAkademik.Domain.Services;

public interface IHolidayService
{
    Task<Result<List<DateOnly>>> GetHolidays(int year);
    Task<bool> IsHoliday(DateOnly date);
}
