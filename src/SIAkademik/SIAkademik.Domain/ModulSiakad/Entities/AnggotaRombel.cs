using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Enums;
using System.Linq;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class AnggotaRombel : Entity<int>
{
    public required int IdSiswa { get; set; }
    public required int IdRombel { get; set; }
    public string CatatanWaliKelas { get; set; } = string.Empty;
    public bool NaikKelasLulus { get; set; } = false;
    public required DateOnly TanggalMasuk { get; set; }
    public DateOnly? TanggalKeluar { get; set; }

    public Rombel Rombel { get; set; }
    public Siswa Siswa { get; set; }
    public List<Absen> DaftarAbsen { get; set; } = [];
    public List<AbsenKelas> DaftarAbsenKelas { get; set; } = [];
    public List<Raport> DaftarRaport { get; set; } = [];

    public List<EvaluasiSiswa> DaftarEvaluasiSiswa { get; set; } = [];
    public List<NilaiEvaluasiSiswa> DaftarNilaiEvaluasiSiswa { get; set; } = [];

    public List<JadwalMengajar> DaftarJadwalMengajar { get; set; } = [];
    public List<AsesmenSumatifAkhirSemester> DaftarAsesmenSumatifAkhirSemester { get; set; } = [];

    public double RataNilai(JadwalMengajar jadwalMengajar) => DaftarNilaiEvaluasiSiswa
            .GroupBy(n => n.EvaluasiSiswa.AsesmenSumatif)
            .Where(g => g.Key.JadwalMengajar == jadwalMengajar)
            .Select(g => g.Count() == 0 ? 0 : g.Average(n => n.Nilai)).Average();

    public double NilaiAkhir(JadwalMengajar jadwalMengajar)
    {
        var asesmenSumatifAkhirSemester = DaftarAsesmenSumatifAkhirSemester.FirstOrDefault(a => a.JadwalMengajar == jadwalMengajar)?.Nilai ?? 0;

        return (RataNilai(jadwalMengajar) + asesmenSumatifAkhirSemester) / 2;
    }

    public string CapaianKompentensi(JadwalMengajar jadwalMengajar)
    {
        var capaian = string.Empty;
        var daftarAsesmen = jadwalMengajar.DaftarAsesmenSumatif.OrderBy(a => a.TujuanPembelajaran.Nomor).ToList();

        var firstAsesmen = daftarAsesmen.FirstOrDefault();
        if (firstAsesmen is null) return capaian;

        capaian += $"Menunjukan penguasaan {firstAsesmen.Predikat(this).ToLower()} dalam hal " +
            firstAsesmen.TujuanPembelajaran.Deskripsi.Substring(0, 1).ToLower() +
            firstAsesmen.TujuanPembelajaran.Deskripsi.Substring(1).Trim('.');

        if (daftarAsesmen.Count == 1) return capaian + ".";

        for (int i = 1; i < daftarAsesmen.Count; i++)
        {
            var asesmen = daftarAsesmen[i];
            capaian += $", serta {asesmen.Predikat(this).ToLower()} dalam hal" +
                asesmen.TujuanPembelajaran.Deskripsi.Substring(0, 1).ToLower() +
                asesmen.TujuanPembelajaran.Deskripsi.Substring(1);
        }

        return capaian + ".";
    }

    public string KeteranganNaikKelasLulus
    {
        get
        {
            var lulus = Rombel.Kelas.Jenjang == Jenjang.XII;
            var value = "Keterangan " + (lulus ? "Lulus" : "Naik Kelas") + " : ";

            if (lulus)
                if (NaikKelasLulus) value += "Lulus SMA";
                else value += "Tidak lulus SMA";
            else
            {
                Jenjang jenjangSelanjutnya = Rombel.Kelas.Jenjang + 1;
                if (NaikKelasLulus) value += $"Naik ke kelas {jenjangSelanjutnya}";
                else value += $"Tidak naik ke kelas {jenjangSelanjutnya}";
            }

            return value;
        }
    }
}
