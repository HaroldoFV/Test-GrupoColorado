using GrupoColorado.Application.Interfaces;
using GrupoColorado.Application.Services;
using GrupoColorado.Domain.Interfaces.Repositories;
using GrupoColorado.Domain.Interfaces.UnitOfWork;
using GrupoColorado.Infra.Data.Contexts;
using GrupoColorado.Infra.Data.Repositories;
using GrupoColorado.Infra.Data.UnitOfWork;

namespace GrupoColorado.Customers.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Application Services
        services.AddTransient<ICustomerAppService, CustomerAppService>();

        // Data
        services.AddScoped<GrupoColoradoContext>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();

        // UnitOfWoark
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}