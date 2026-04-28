using MediatR;
using RDS.Core.Application.DTOs;
using RDS.Core.Application.Interfaces;
using RDS.Core.Domain.Entities;
using RDS.Core.Shared.Results;

namespace RDS.Core.Application.Produtos.Queries;

public class ListarProdutosHandler(IProdutoRepository repo)
    : IRequestHandler<ListarProdutosQuery, Result<IReadOnlyList<ProdutoDto>>>
{
    public async Task<Result<IReadOnlyList<ProdutoDto>>> Handle(ListarProdutosQuery _, CancellationToken ct)
    {
        var produtos = await repo.ListarAtivosAsync(ct);
        var dtos = produtos.Select(ToDto).ToList().AsReadOnly();
        return Result.Ok<IReadOnlyList<ProdutoDto>>(dtos);
    }

    private static ProdutoDto ToDto(Produto p) => new(
        p.Id, p.SKU, p.Nome, p.Descricao, p.PrecoUnitario,
        p.EstoqueMinimo, p.UnidadeMedida?.Sigla ?? "", p.Ativo);
}
