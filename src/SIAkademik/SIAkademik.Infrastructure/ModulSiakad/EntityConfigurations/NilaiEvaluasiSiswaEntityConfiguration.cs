using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class NilaiEvaluasiSiswaEntityConfiguration : IEntityTypeConfiguration<NilaiEvaluasiSiswa>
{
    public void Configure(EntityTypeBuilder<NilaiEvaluasiSiswa> builder)
    {
        builder.HasData(
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 1,
                Nilai = 100
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 2,
                Nilai = 100
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 3,
                Nilai = 91
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 4,
                Nilai = 91
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 5,
                Nilai = 90
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 6,
                Nilai = 90
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 7,
                Nilai = 90
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 8,
                Nilai = 90
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 9,
                Nilai = 89
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 10,
                Nilai = 89
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 11,
                Nilai = 87
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 12,
                Nilai = 87
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 13,
                Nilai = 93
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 14,
                Nilai = 93
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 15,
                Nilai = 86
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 16,
                Nilai = 86
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 17,
                Nilai = 90
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 18,
                Nilai = 90
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 19,
                Nilai = 92
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 20,
                Nilai = 92
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 21,
                Nilai = 86
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 22,
                Nilai = 86
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 23,
                Nilai = 95
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 24,
                Nilai = 95
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 25,
                Nilai = 97
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 26,
                Nilai = 97
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 27,
                Nilai = 90
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 28,
                Nilai = 90
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 29,
                Nilai = 87
            },
            new NilaiEvaluasiSiswa
            {
                IdAnggotaRombel = 1,
                IdEvaluasiSiswa = 30,
                Nilai = 87
            }
        );
    }
}
