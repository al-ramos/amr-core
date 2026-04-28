namespace RDS.Core.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync(CancellationToken ct = default);
}
