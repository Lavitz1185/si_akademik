using SIAkademik.Domain.ModulSiakad.Entities;

namespace SIAkademik.Domain.ModulSiakad.Repositories;

public interface IAsesmenSumatifRepository
{
    Task<AsesmenSumatif?> Get(int id);
    Task<List<AsesmenSumatif>> GetAll();
    Task<List<AsesmenSumatif>> GetAll(int idTujuanPembelajaran, int idJadwalMengajar);

    void Add(AsesmenSumatif asesmenSumatif);
    void Delete(AsesmenSumatif asesmenSumatif);
}
