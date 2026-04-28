using Microsoft.EntityFrameworkCore;
using RDS.Core.Domain.Entities;

namespace RDS.Core.Infrastructure.Data;

public class RdsCoreDbContext(DbContextOptions<RdsCoreDbContext> options) : DbContext(options)
{
    public DbSet<Empresa>           Empresas           => Set<Empresa>();
    public DbSet<Cliente>           Clientes           => Set<Cliente>();
    public DbSet<Fornecedor>        Fornecedores       => Set<Fornecedor>();
    public DbSet<UnidadeMedida>     UnidadesMedida     => Set<UnidadeMedida>();
    public DbSet<Produto>           Produtos           => Set<Produto>();
    public DbSet<PedidoCompra>      PedidosCompra      => Set<PedidoCompra>();
    public DbSet<ItemPedidoCompra>  ItensPedidoCompra  => Set<ItemPedidoCompra>();
    public DbSet<PedidoVenda>       PedidosVenda       => Set<PedidoVenda>();
    public DbSet<ItemPedidoVenda>   ItensPedidoVenda   => Set<ItemPedidoVenda>();
    public DbSet<SaldoEstoque>      SaldosEstoque      => Set<SaldoEstoque>();
    public DbSet<MovimentoEstoque>  MovimentosEstoque  => Set<MovimentoEstoque>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.HasDefaultSchema("erp");
        mb.ApplyConfigurationsFromAssembly(typeof(RdsCoreDbContext).Assembly);
        base.OnModelCreating(mb);
    }
}
