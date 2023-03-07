using EdataProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdataProject.Infra.Data.EntitiesConfiguration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Cpf).HasMaxLength(14).IsRequired();
        builder.Property(p => p.BirthDate).HasColumnType("datetime")
            .IsRequired();
        builder.Property(p => p.Email).HasMaxLength(200).IsRequired();
    }
}