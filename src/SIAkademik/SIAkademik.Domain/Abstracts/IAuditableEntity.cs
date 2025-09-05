namespace SIAkademik.Domain.Abstracts;

public interface IAuditableEntity
{
    DateTime DateAdded { get; set; }
    DateTime? DateModified { get; set; }
}