using RDS.Core.Application.Interfaces;

namespace RDS.Core.Infrastructure.Data;

public class UnitOfWork(RdsCoreDbContext ctx) : IUnitOfWork
{
    public Task<int> CommitAsync(CancellationToken ct = default) => ctx.SaveChangesAsync(ct);
    public void Dispose() => ctx.Dispose();
}
