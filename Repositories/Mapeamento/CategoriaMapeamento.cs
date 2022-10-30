using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace Repository.Mapeamento
{
    public class CategoriaMapeamento : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categorias");

            builder.HasKey(x => x.Id); // Primary Key

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasData(
                new Categoria
                {
                    Id = 1,
                    Nome = "Ação"
                },
                new Categoria
                {
                    Id = 2,
                    Nome = "Romance"
                },
                new Categoria
                {
                    Id = 3,
                    Nome = "Programação"
                });
        }
    }
}