namespace SIAkademik.Domain.Abstracts;

public interface IAuditableEntity
{
    DateTime TanggalDitambahkan { get; set; }
    DateTime? TanggalDiubah { get; set; }
}