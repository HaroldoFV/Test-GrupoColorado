using GrupoColorado.Domain.Entities;
using GrupoColorado.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GrupoColorado.Infra.Data.Contexts;

public sealed class GrupoColoradoContext : DbContext
{
    public GrupoColoradoContext(DbContextOptions<GrupoColoradoContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Enable LazyLoading for mappings
        optionsBuilder.UseLazyLoadingProxies();

        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GrupoColoradoContext).Assembly);
    }
}