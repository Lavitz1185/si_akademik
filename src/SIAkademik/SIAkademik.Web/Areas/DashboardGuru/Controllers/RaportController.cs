using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Web.Areas.DashboardGuru.Models.RaportModels;
using SIAkademik.Web.Authentication;

namespace SIAkademik.Web.Areas.DashboardGuru.Controllers;

[Area(AreaNames.DashboardGuru)]
[Authorize(Roles = AppUserRoles.Guru)]
public class RaportController : Controller
{
    private readonly IRombelRepository _rombelRepository;
    private readonly ISignInManager _signInManager;
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly ISiswaRepository _siswaRepository;
    private readonly IRaportRepository _raportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RaportController(
        IRombelRepository rombelRepository,
        ISignInManager signInManager,
        ITahunAjaranRepository tahunAjaranRepository,
        ISiswaRepository siswaRepository,
        IRaportRepository raportRepository,
        IUnitOfWork unitOfWork)
    {
        _rombelRepository = rombelRepository;
        _signInManager = signInManager;
        _tahunAjaranRepository = tahunAjaranRepository;
        _siswaRepository = siswaRepository;
        _raportRepository = raportRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(int? idTahunAjaran = null, int? idRombel = null)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var tahunAjaran = idTahunAjaran is null ?
            await _tahunAjaranRepository.GetNewest() :
            await _tahunAjaranRepository.Get(idTahunAjaran.Value);

        if (tahunAjaran is null) return View(new IndexVM());

        if (idRombel is null) return View(new IndexVM { TahunAjaran = tahunAjaran });

        var rombel = await _rombelRepository.Get(idRombel.Value);
        if (rombel is null) return NotFound();

        if (!pegawai.DaftarRombelWali.Contains(rombel)) return BadRequest();

        return View(new IndexVM { TahunAjaran = tahunAjaran, Rombel = rombel });
    }

    public async Task<IActionResult> Detail(int idSiswa, int idRombel)
    {
        var pegawai = await _signInManager.GetPegawai();
        if (pegawai is null) return Forbid();

        var rombel = await _rombelRepository.Get(idRombel);
        if (rombel is null) return NotFound();
        if (!pegawai.DaftarRombelWali.Contains(rombel)) return BadRequest();

        var siswa = await _siswaRepository.Get(idSiswa);
        if (siswa is null) return NotFound();

        var anggotaRombel = rombel.DaftarAnggotaRombel.Where(a => a.Siswa == siswa).FirstOrDefault();
        if (anggotaRombel is null) return BadRequest();

        var daftarRaport = await _raportRepository.GetAllBy(siswa.Id, rombel.Id);

        foreach (var jadwal in rombel.DaftarJadwalMengajar)
        {
            if(!daftarRaport.Any(r => r.JadwalMengajar == jadwal))
            {
                var raportPengetahuan = new Raport
                {
                    JadwalMengajar = jadwal,
                    AnggotaRombel = anggotaRombel,
                    Deskripsi = string.Empty,
                    KategoriNilai = KategoriNilaiRaport.Pengetahuan,
                    Nama = jadwal.MataPelajaran.Nama,
                    Predikat = string.Empty
                };

                var raportKeterampilan = new Raport
                {
                    JadwalMengajar = jadwal,
                    AnggotaRombel = anggotaRombel,
                    Deskripsi = string.Empty,
                    KategoriNilai = KategoriNilaiRaport.Keterampilan,
                    Nama = jadwal.MataPelajaran.Nama,
                    Predikat = string.Empty
                };

                _raportRepository.Add(raportPengetahuan);
                _raportRepository.Add(raportKeterampilan);
            }
        }

        var result = await _unitOfWork.SaveChangesAsync();

        daftarRaport = await _raportRepository.GetAllBy(siswa.Id, rombel.Id);

        return View(new DetailVM { AnggotaRombel = anggotaRombel, DaftarRaport = daftarRaport});
    }
}
