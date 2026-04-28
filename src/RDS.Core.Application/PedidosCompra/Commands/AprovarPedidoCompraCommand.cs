using MediatR;
using RDS.Core.Application.DTOs;
using RDS.Core.Shared.Results;

namespace RDS.Core.Application.PedidosCompra.Commands;

public record AprovarPedidoCompraCommand(int PedidoId) : IRequest<Result<PedidoCompraDto>>;
