using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IAsesmenSumatifAkhirSemesterRepository
{
    void Add(AsesmenSumatifAkhirSemester asesmenSumatifAkhirSemester);
    void Delete(AsesmenSumatifAkhirSemester asesmenSumatifAkhirSemester);
}
