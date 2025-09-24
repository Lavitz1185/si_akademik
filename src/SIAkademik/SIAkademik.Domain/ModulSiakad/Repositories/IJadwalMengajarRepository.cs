using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IJadwalMengajarRepository
{
    Task<JadwalMengajar?> Get(int id);
    Task<List<JadwalMengajar>> GetAll();
    Task<List<JadwalMengajar>> GetAllByTahunAjaran(int idTahunAjaran);
    Task<bool> IsExist(int idMataPelajaran, int idRombel, string nipPegawai, int? id = null);
    void Add(JadwalMengajar jadwalMengajar);
    void Delete(JadwalMengajar jadwalMengajar);
}
