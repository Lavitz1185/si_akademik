using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Infrastructure.Database;

namespace SIAkademik.Infrastructure.ModulSiakad.Repositories;

internal class NilaiEvaluasiSiswaRepository : INilaiEvaluasiSiswaRepository
{
    private readonly AppDbContext _appDbContext;

    public NilaiEvaluasiSiswaRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(NilaiEvaluasiSiswa nilaiEvaluasiSiswa) => _appDbContext.TblNilaiEvaluasiSiswa.Add(nilaiEvaluasiSiswa);

    public void Delete(NilaiEvaluasiSiswa nilaiEvaluasiSiswa) => _appDbContext.TblNilaiEvaluasiSiswa.Remove(nilaiEvaluasiSiswa);

    public void Update(NilaiEvaluasiSiswa nilaiEvaluasiSiswa) => _appDbContext.TblNilaiEvaluasiSiswa.Update(nilaiEvaluasiSiswa);
}
