using SIAkademik.Domain.ValueObjects;

namespace SIAkademik.Web.Models;

public interface IHaveAlamat
{
    Alamat Alamat { get; set; }
}
