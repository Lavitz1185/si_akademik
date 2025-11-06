using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IJadwalMengajarRepository
{
    Task<JadwalMengajar?> Get(int id);
    Task<List<JadwalMengajar>> GetAll();
    Task<List<JadwalMengajar>> GetAllByTahunAjaranAndPegawai(int idTahunAjaran, string nipPegawai);
    Task<List<JadwalMengajar>> GetAllByTahunAjaran(int idTahunAjaran);
    Task<List<JadwalMengajar>> GetAllByTahunAjaranAndRombel(int idTahunAjaran, int idRombel);
    Task<bool> IsExist(int idMataPelajaran, int idRombel, string nipPegawai, int? id = null);
    void Add(JadwalMengajar jadwalMengajar);
    void Delete(JadwalMengajar jadwalMengajar);
}
