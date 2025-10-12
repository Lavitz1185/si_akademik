using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class AsesmenSumatifAkhirSemesterRepository : IAsesmenSumatifAkhirSemesterRepository
{
    private readonly AppDbContext _appDbContext;

    public AsesmenSumatifAkhirSemesterRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(AsesmenSumatifAkhirSemester asesmenSumatifAkhirSemester) =>
        _appDbContext.TblAsesmenSumatifAkhirSemester.Add(asesmenSumatifAkhirSemester);

    public void Delete(AsesmenSumatifAkhirSemester asesmenSumatifAkhirSemester) =>
        _appDbContext.TblAsesmenSumatifAkhirSemester.Remove(asesmenSumatifAkhirSemester);
}
