using SIAkademik.Domain.Abstracts;

namespace SIAkademik.Domain.ModulSiakad.Entities;

public class AsesmenSumatif : Entity<int>
{
    public required int IdTujuanPembelajaran { get; set; }
    public required int IdJadwalMengajar { get; set; }
    public required double BatasBawahCukup { get; set; }
    public required double BatasBawahBaik { get; set; }
    public required double BatasBawahSangatBaik { get; set; }

    public TujuanPembelajaran TujuanPembelajaran { get; set; }
    public JadwalMengajar JadwalMengajar { get; set; }
    public List<EvaluasiSiswa> DaftarEvaluasiSiswa { get; set; } = [];

    public double RataNilai(AnggotaRombel anggotaRombel)
    {
        var daftarNilaiEvaluasiSiswa = DaftarEvaluasiSiswa
            .SelectMany(e => e.DaftarNilaiEvaluasiSiswa)
            .Where(n => n.AnggotaRombel == anggotaRombel)
            .Select(n => n.Nilai);

        return daftarNilaiEvaluasiSiswa.Count() == 0 ? 0 : daftarNilaiEvaluasiSiswa.Average();
    }

    public string Predikat(AnggotaRombel anggotaRombel)
    {
        var rataNilai = RataNilai(anggotaRombel);

        if (rataNilai >= 0 && rataNilai < BatasBawahCukup) return "Tidak Cukup";
        if (rataNilai >= BatasBawahCukup && rataNilai < BatasBawahBaik) return "Cukup";
        if (rataNilai >= BatasBawahBaik && rataNilai < BatasBawahSangatBaik) return "Baik";
        return "Sangat Baik";
    }
}