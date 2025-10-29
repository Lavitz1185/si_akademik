using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.Services;
using SIAkademik.Domain.Shared;
using System.Threading.Tasks;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class JadwalMengajar : Entity<int>
{
    public Pegawai Pegawai { get; set; }
    public MataPelajaran MataPelajaran { get; set; }
    public Rombel Rombel { get; set; }
    public List<Raport> DaftarRaport { get; set; } = [];
    public List<HariMengajar> DaftarHariMengajar { get; set; } = [];
    public List<EvaluasiSiswa> DaftarEvaluasiSiswa { get; set; } = [];
    public List<Pertemuan> DaftarPertemuan { get; set; } = [];

    public List<TujuanPembelajaran> DaftarTujuanPembelajaran { get; set; } = [];
    public List<AsesmenSumatif> DaftarAsesmenSumatif { get; set; } = [];

    public List<AnggotaRombel> DaftarAnggotaRombel { get; set; } = [];
    public List<AsesmenSumatifAkhirSemester> DaftarAsesmenSumatifAkhirSemester { get; set; } = [];

    public async Task<Result> AddPertemuan(int numberOfPertemuan, IHolidayService holidayService)
    {
        if (Rombel?.TahunAjaran is null) return new Error("JadwalMengajar.TahunAjaran", "Tahun Ajaran null");

        if (DaftarHariMengajar.Count == 0) return new Error("JadwalMengajar.HariMengajar", "Tidak ada hari mengajar");

        var numAdded = 0;
        var orderedHariMengajar = DaftarHariMengajar.OrderBy(h => h.Hari).ThenBy(h => h.JamMulai).ToList();
        for(int i = 0; i < orderedHariMengajar.Count; i++)
        {
            var hariMengajar = orderedHariMengajar[i];

            var closest = Rombel.TahunAjaran.TanggalMulai;
            while (closest.DayOfWeek != HariExtension.FromHari(hariMengajar.Hari))
                closest = closest.AddDays(1);

            var nomor = i + 1;
            do
            {
                if (!await holidayService.IsHoliday(closest))
                    DaftarPertemuan.Add(new Pertemuan
                    {
                        Nomor = nomor,
                        StatusPertemuan = StatusPertemuan.BelumMulai,
                        TanggalPelaksanaan = new DateTime(closest, hariMengajar.JamMulai)
                    });

                nomor += DaftarHariMengajar.Count;
                closest = closest.AddDays(7);
                numAdded++;
            } while (numAdded <= numberOfPertemuan && closest <= Rombel.TahunAjaran.TanggalSelesai);
        }

        return Result.Success();
    }
}
