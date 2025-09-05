using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IPegawaiRepository
{
    Task<Pegawai?> Get(string nip);
    Task<List<Pegawai>> GetAll();

    void Add(Pegawai pegawai);
    void Delete(Pegawai pegawai);
}
