using MediatR;
using RDS.Core.Application.DTOs;
using RDS.Core.Shared.Results;

namespace RDS.Core.Application.Produtos.Queries;

public record ListarProdutosQuery() : IRequest<Result<IReadOnlyList<ProdutoDto>>>;
