using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.ModulSiakad.EntityConfigurations;

internal class JabatanEntityConfiguration : IEntityTypeConfiguration<Jabatan>
{
    public void Configure(EntityTypeBuilder<Jabatan> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DaftarPegawai).WithOne(x => x.Jabatan);

        builder.HasData(
            new Jabatan
            {
                Id = 1,
                Nama = "Guru Matematika",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 2,
                Nama = JabatanKhusus.KepalaSekolah,
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 3,
                Nama = "Wakil Kepala Bidang Kesiswaan",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 4,
                Nama = "Kepala Asrama",
                Jenis = JenisJabatan.Pegawai
            },
            new Jabatan
            {
                Id = 5,
                Nama = "Guru Honor Olahraga",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 6,
                Nama = "Wakil Kepala Bidang Kurikulum",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 7,
                Nama = "Pembina OSIS",
                Jenis = JenisJabatan.Pegawai
            },
            new Jabatan
            {
                Id = 8,
                Nama = "Guru Honor Geografi",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 9,
                Nama = "Karyawan Pengadaan dan Keuangan",
                Jenis = JenisJabatan.Pegawai
            },
            new Jabatan
            {
                Id = 10,
                Nama = "Guru Honor Fisika",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 11,
                Nama = "Guru Honor Bahasa Indonesia",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 12,
                Nama = "Guru English Center",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 13,
                Nama = "Guru PPKN",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 14,
                Nama = "Guru Biologi",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 15,
                Nama = "Kordinator Pengadaan dan Keuangan",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 16,
                Nama = "Direktor Sekolah",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 17,
                Nama = "Guru Honor",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 18,
                Nama = "Guru Honor Ekonomi",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 19,
                Nama = "Guru Honor Matematika",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 20,
                Nama = "Kordinator Operasional dan Kor DPU",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 21,
                Nama = "Kordinator Sekolah",
                Jenis = JenisJabatan.Guru
            },
            new Jabatan
            {
                Id = 22,
                Nama = "Karyawan SPV DPU",
                Jenis = JenisJabatan.Pegawai
            },
            new Jabatan
            {
                Id = 23,
                Nama = "Karyawan Pengadaan dan Keuangan",
                Jenis = JenisJabatan.Pegawai
            },
            new Jabatan
            {
                Id = 24,
                Nama = "Karyawan DPU",
                Jenis = JenisJabatan.Pegawai
            },
            new Jabatan
            {
                Id = 25,
                Nama = "Kordinator HRD",
                Jenis = JenisJabatan.Pegawai
            },
            new Jabatan
            {
                Id = 26,
                Nama = "Kordinator R&D",
                Jenis = JenisJabatan.Pegawai
            },
            new Jabatan
            {
                Id = 27,
                Nama = "Karyawan Dapur",
                Jenis = JenisJabatan.Pegawai
            }
        );
    }
}
