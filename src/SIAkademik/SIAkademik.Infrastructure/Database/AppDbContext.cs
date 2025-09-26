using Microsoft.EntityFrameworkCore;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Infrastructure.Database;

internal class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes().ToList())
        {
            if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType).Property(nameof(IAuditableEntity.DateAdded))
                    .HasColumnType("timestamp without time zone");
                modelBuilder.Entity(entityType.ClrType).Property(nameof(IAuditableEntity.DateModified))
                    .HasColumnType("timestamp without time zone");
            }
        }

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<AppUser> AppUser { get; set; }

    public DbSet<Absen> TblAbsen { get; set; }
    public DbSet<AnggotaRombel> TblAnggotaRombel { get; set; }
    public DbSet<Divisi> TblDivisi { get; set; }
    public DbSet<HariMengajar> TblHariMengajar { get; set; }
    public DbSet<Jabatan> TblJabatan { get; set; }
    public DbSet<JadwalMengajar> TblJadwalMengajar { get; set; }
    public DbSet<Kelas> TblKelas { get; set; }
    public DbSet<MataPelajaran> TblMataPelajaran { get; set; }
    public DbSet<Nilai> TblNilai { get; set; }
    public DbSet<Pegawai> TblPegawai { get; set; }
    public DbSet<Pertemuan> TblPertemuan { get; set; }
    public DbSet<Rombel> TblRombel { get; set; }
    public DbSet<Siswa> TblSiswa { get; set; }
    public DbSet<TahunAjaran> TblTahunAjaran { get; set; }
}
