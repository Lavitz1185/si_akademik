using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IPegawaiRepository
{
    Task<Pegawai?> Get(string nip);
    Task<List<Pegawai>> GetAll();

    void Add(Pegawai pegawai);
    void Delete(Pegawai pegawai);
}
