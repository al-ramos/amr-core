using MediatR;
using RDS.Core.Application.DTOs;
using RDS.Core.Shared.Results;

namespace RDS.Core.Application.PedidosVenda.Commands;

public record FaturarPedidoVendaCommand(int PedidoId) : IRequest<Result<PedidoVendaDto>>;
