using SIAkademik.Domain.Shared;

namespace SIAkademik.Domain.Abstracts;

public interface IUnitOfWork
{
    Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default);
}
