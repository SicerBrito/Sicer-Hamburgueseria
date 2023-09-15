using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class IngredienteConfiguration : IEntityTypeConfiguration<Ingrediente>
{
    public void Configure(EntityTypeBuilder<Ingrediente> builder)
    {
        builder.ToTable("Ingrediente");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdIngrediente")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.NombreIngrediente)
            .HasColumnName("NombreIngrediente")
            .HasColumnType("varchar")
            .HasMaxLength(35)
            .IsRequired();

        builder.Property(p => p.DescripcionIngrediente)
            .HasColumnName("DescripcionIngrediente")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.PrecioIngrediente)
            .HasColumnName("PrecioIngrediente")
            .HasColumnType("BIGINT")
            .IsRequired();


        builder.Property(p => p.StockIngrediente)
            .HasColumnName("StockIngrediente")
            .HasColumnType("int")
            .IsRequired();
    }
}
