using Microsoft.EntityFrameworkCore;
using RDS.Core.Application.Interfaces;
using RDS.Core.Domain.Entities;
using RDS.Core.Infrastructure.Data;

namespace RDS.Core.Infrastructure.Data.Repositories;

public class PedidoCompraRepository(RdsCoreDbContext ctx) : IPedidoCompraRepository
{
    public Task<PedidoCompra?> ObterPorIdAsync(int id, CancellationToken ct = default) =>
        ctx.PedidosCompra
            .Include(p => p.Itens).ThenInclude(i => i.Produto)
            .FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task<IReadOnlyList<PedidoCompra>> ListarPorEmpresaAsync(int empresaId, CancellationToken ct = default) =>
        await ctx.PedidosCompra
            .Include(p => p.Itens)
            .Where(p => p.EmpresaId == empresaId)
            .OrderByDescending(p => p.DataEmissao)
            .ToListAsync(ct);

    public Task AdicionarAsync(PedidoCompra pedido, CancellationToken ct = default) =>
        ctx.PedidosCompra.AddAsync(pedido, ct).AsTask();

    public Task AtualizarAsync(PedidoCompra pedido, CancellationToken ct = default)
    {
        ctx.PedidosCompra.Update(pedido);
        return Task.CompletedTask;
    }
}
