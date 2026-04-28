using MediatR;
using RDS.Core.Application.DTOs;
using RDS.Core.Shared.Results;

namespace RDS.Core.Application.PedidosCompra.Queries;

public record ObterPedidoCompraQuery(int PedidoId) : IRequest<Result<PedidoCompraDto>>;
