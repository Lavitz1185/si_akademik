using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IPegawaiRepository
{
    Task<Pegawai?> Get(string nip);
    Task<List<Pegawai>> GetAll();
    Task<bool> IsExistByEmail(string email, string? nip = null);
    Task<bool> IsExist(string nip);

    void Add(Pegawai pegawai);
    void Delete(Pegawai pegawai);
}
