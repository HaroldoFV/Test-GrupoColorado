using GrupoColorado.Domain.Entities;
using GrupoColorado.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoColorado.Infra.Data.Mappings;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");

        builder.HasKey(x => new {x.CustomerId});

        builder.Property(x => x.CustomerId)
            .HasColumnName("customer_id");

        builder.Property(x => x.Street)
            .HasColumnName("street");

        builder.Property(x => x.Number)
            .HasColumnName("number");

        builder.Property(x => x.Neighborhood)
            .HasColumnName("neighborhood");

        builder.Property(x => x.City)
            .HasColumnName("city");

        builder.Property(x => x.State)
            .HasColumnName("state");

        builder.Property(x => x.Country)
            .HasColumnName("country");

        builder.Property(x => x.ZipCode)
            .HasColumnName("zip_code");

        builder.HasOne(d => d.Customer)
            .WithOne(r => r.Address)
            .HasForeignKey<Address>(d => d.CustomerId);
    }
}