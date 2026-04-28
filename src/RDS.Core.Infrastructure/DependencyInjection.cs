using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RDS.Core.Application.Interfaces;
using RDS.Core.Infrastructure.Data;
using RDS.Core.Infrastructure.Data.Repositories;

namespace RDS.Core.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<RdsCoreDbContext>(opts =>
            opts.UseSqlServer(
                configuration.GetConnectionString("RdsCore"),
                sql => sql.MigrationsAssembly(typeof(RdsCoreDbContext).Assembly.FullName)));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IPedidoCompraRepository, PedidoCompraRepository>();
        services.AddScoped<IPedidoVendaRepository, PedidoVendaRepository>();
        services.AddScoped<ISaldoEstoqueRepository, SaldoEstoqueRepository>();

        return services;
    }
}
