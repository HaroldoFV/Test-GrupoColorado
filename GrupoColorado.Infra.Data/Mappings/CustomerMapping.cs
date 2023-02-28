using GrupoColorado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoColorado.Infra.Data.Mappings;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customer");

        builder.HasKey(x => new {x.Id});
        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasColumnName("name");

        builder.Property(x => x.City)
            .HasColumnName("city");

        builder.Property(x => x.State)
            .HasColumnName("state");

        builder.Property(x => x.DateInsert)
            .HasColumnName("date_insert")
            .HasColumnType("timestamp");
    }
}