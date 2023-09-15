using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class HamburgesaConfiguration : IEntityTypeConfiguration<Hamburgesa>
{
    public void Configure(EntityTypeBuilder<Hamburgesa> builder)
    {
        builder.ToTable("Hamburgesa");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdHamburgesa")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.NombreHamburgesa)
            .HasColumnName("NombreHamburgesa")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.CategoriaId)
            .HasColumnName("CategoriaId")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();

        builder.HasOne(p => p.Categorias)
            .WithMany(p => p.Hamburgesas)
            .HasForeignKey(p => p.CategoriaId);

        builder.Property(p => p.Precio)
            .HasColumnName("Precio")
            .HasColumnType("BIGINT")
            .IsRequired();

        builder.Property(p => p.ChefId)
            .HasColumnName("ChefId")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(p => p.Chefs)
            .WithMany(p => p.Hamburgesas)
            .HasForeignKey(p => p.ChefId);
            
    }
}
