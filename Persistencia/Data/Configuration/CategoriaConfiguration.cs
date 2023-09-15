using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categoria");
        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdCategoria")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.NombreCategoria)
            .HasColumnName("NombreCategoria")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();

        builder.Property(p => p.DescripcionCategoria)
            .HasColumnName("DescripcionCategoria")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();
    }
}
