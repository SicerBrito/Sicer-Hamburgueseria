using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class HamburgesaIngredienteConfiguration : IEntityTypeConfiguration<HamburgesaIngrediente>
{
    public void Configure(EntityTypeBuilder<HamburgesaIngrediente> builder)
    {
        builder.ToTable("HamburgesaIngrediente");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdHamburgesaIngrediente")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.HamburgesaId)
            .HasColumnName("HamburgesaId")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Hamburgesas)
            .WithMany(p => p.HamburgesaIngredientes)
            .HasForeignKey(p => p.HamburgesaId);

        builder.Property(p => p.IngredienteId)
            .HasColumnName("IngredienteId")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Ingredientes)
            .WithMany(p => p.HamburgesaIngredientes)
            .HasForeignKey(p => p.IngredienteId);
    }
}
