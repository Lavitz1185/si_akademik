using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IAbsenKelasRepository
{
    Task<AbsenKelas?> Get(int id);
    Task<List<AbsenKelas>> GetAll();
    Task<List<AbsenKelas>> GetAllBySiswa(int idSiswa);
    Task<List<AbsenKelas>> GetAllByRombel(int idRombel);

    void Add(AbsenKelas absenKelas);
    void Delete(AbsenKelas absenKelas);
    void Update(AbsenKelas absenKelas);
}
