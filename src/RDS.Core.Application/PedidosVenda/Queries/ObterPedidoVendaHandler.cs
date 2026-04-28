using MediatR;
using RDS.Core.Application.DTOs;
using RDS.Core.Application.Interfaces;
using RDS.Core.Application.PedidosVenda.Commands;
using RDS.Core.Shared.Results;

namespace RDS.Core.Application.PedidosVenda.Queries;

public class ObterPedidoVendaHandler(IPedidoVendaRepository repo)
    : IRequestHandler<ObterPedidoVendaQuery, Result<PedidoVendaDto>>
{
    public async Task<Result<PedidoVendaDto>> Handle(ObterPedidoVendaQuery q, CancellationToken ct)
    {
        var pedido = await repo.ObterPorIdAsync(q.PedidoId, ct);
        if (pedido is null)
            return Result.Falha<PedidoVendaDto>($"Pedido de venda #{q.PedidoId} não encontrado.");

        return Result.Ok(CriarPedidoVendaHandler.ToDto(pedido));
    }
}
