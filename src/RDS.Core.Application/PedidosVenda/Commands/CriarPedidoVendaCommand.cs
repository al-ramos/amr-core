using MediatR;
using RDS.Core.Application.DTOs;
using RDS.Core.Shared.Results;

namespace RDS.Core.Application.PedidosVenda.Commands;

public record ItemPedidoVendaInput
{
    public int     ProdutoId     { get; init; }
    public decimal Quantidade    { get; init; }
    public decimal PrecoUnitario { get; init; }
    public decimal Desconto      { get; init; }
}

public record CriarPedidoVendaCommand : IRequest<Result<PedidoVendaDto>>
{
    public int     EmpresaId  { get; init; }
    public int     ClienteId  { get; init; }
    public string? Observacao { get; init; }
    public IReadOnlyList<ItemPedidoVendaInput> Itens { get; init; } = [];
}
