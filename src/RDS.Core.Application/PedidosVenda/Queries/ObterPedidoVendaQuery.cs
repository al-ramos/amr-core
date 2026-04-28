using MediatR;
using RDS.Core.Application.DTOs;
using RDS.Core.Shared.Results;

namespace RDS.Core.Application.PedidosVenda.Queries;

public record ObterPedidoVendaQuery(int PedidoId) : IRequest<Result<PedidoVendaDto>>;
