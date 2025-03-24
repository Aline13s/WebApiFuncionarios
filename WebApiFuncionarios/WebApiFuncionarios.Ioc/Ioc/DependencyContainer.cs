using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApiFuncionarios.Data.Context;
using WebApiFuncionarios.Interfaces;
using WebApiFuncionarios.Repositories;
using WebApiFuncionarios.Services;
using Microsoft.Extensions.Configuration;
using WebApiFuncionarios.Data;

namespace WebApiFuncionarios.Ioc;

public static class DependencyContainer
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        services.AddScoped<IFuncionarioService, FuncionarioService>();

        return services;
    }
}
