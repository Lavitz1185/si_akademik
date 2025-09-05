using SIAkademik.Domain.Entities;

namespace SIAkademik.Domain.Repositories;

public interface IPegawaiRepository
{
    Task<Pegawai?> Get(string nip);
    Task<List<Pegawai>> GetAll();

    Task Add(Pegawai pegawai);
    Task Delete(Pegawai pegawai);
}
