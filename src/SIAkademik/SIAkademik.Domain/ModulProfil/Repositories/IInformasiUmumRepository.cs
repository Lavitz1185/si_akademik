using SIAkademik.Domain.ModulProfil.Entities;

namespace SIAkademik.Domain.ModulProfil.Repositories;

public interface IInformasiUmumRepository
{
    Task<InformasiUmum> Get();

    void Update(InformasiUmum informasiUmum);
}
