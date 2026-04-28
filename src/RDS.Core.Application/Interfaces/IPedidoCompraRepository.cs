using RDS.Core.Domain.Entities;

namespace RDS.Core.Application.Interfaces;

public interface IPedidoCompraRepository
{
    Task<PedidoCompra?> ObterPorIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<PedidoCompra>> ListarPorEmpresaAsync(int empresaId, CancellationToken ct = default);
    Task AdicionarAsync(PedidoCompra pedido, CancellationToken ct = default);
    Task AtualizarAsync(PedidoCompra pedido, CancellationToken ct = default);
}
