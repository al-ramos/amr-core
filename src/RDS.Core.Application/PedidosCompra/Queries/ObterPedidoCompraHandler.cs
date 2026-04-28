using MediatR;
using RDS.Core.Application.DTOs;
using RDS.Core.Application.Interfaces;
using RDS.Core.Application.PedidosCompra.Commands;
using RDS.Core.Shared.Results;

namespace RDS.Core.Application.PedidosCompra.Queries;

public class ObterPedidoCompraHandler(IPedidoCompraRepository repo)
    : IRequestHandler<ObterPedidoCompraQuery, Result<PedidoCompraDto>>
{
    public async Task<Result<PedidoCompraDto>> Handle(ObterPedidoCompraQuery q, CancellationToken ct)
    {
        var pedido = await repo.ObterPorIdAsync(q.PedidoId, ct);
        if (pedido is null)
            return Result.Falha<PedidoCompraDto>($"Pedido de compra #{q.PedidoId} não encontrado.");

        return Result.Ok(CriarPedidoCompraHandler.ToDto(pedido));
    }
}
