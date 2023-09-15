using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ChefConfiguration : IEntityTypeConfiguration<Chef>
{
    public void Configure(EntityTypeBuilder<Chef> builder)
    {
        builder.ToTable("Chef");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdChef")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.NombreChef)
            .HasColumnName("NombreChef")
            .HasColumnType("varchar")
            .HasMaxLength(35)
            .IsRequired();

        builder.Property(p => p.EspecialidadChef)
            .HasColumnName("EspecialidadChef")
            .HasColumnType("varchar")
            .HasMaxLength(35)
            .IsRequired();

    }
}
