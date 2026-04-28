using MediatR;
using RDS.Core.Application.DTOs;
using RDS.Core.Shared.Results;

namespace RDS.Core.Application.Produtos.Commands;

public record CriarProdutoCommand : IRequest<Result<ProdutoDto>>
{
    public string  SKU            { get; init; } = string.Empty;
    public string  Nome           { get; init; } = string.Empty;
    public string? Descricao      { get; init; }
    public decimal PrecoUnitario  { get; init; }
    public int     UnidadeMedidaId { get; init; }
    public decimal EstoqueMinimo  { get; init; }
}
