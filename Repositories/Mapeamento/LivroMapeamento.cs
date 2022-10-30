using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace Repository.Mapeamento
{
    public class LivroMapeamento : IEntityTypeConfiguration<Livro>
    {
        private int id = 0;

        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("livros");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnName("titulo");

            builder.Property(x => x.Isbn)
                .HasColumnType("VARCHAR")
                .HasMaxLength(13)
                .IsRequired()
                .HasColumnName("isbn");

            builder.Property(x => x.QuantidadePaginas)
                .HasColumnType("SMALLINT")
                .IsRequired()
                .HasColumnName("quantidade_paginas");

            builder.Property(x => x.Preco)
                //.HasColumnType("DECIMAL(14,2)")
                .HasPrecision(14, 2)
                .IsRequired()
                .HasColumnName("preco");

            builder.Property(x => x.CategoriaId)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("categoria_id");

            // Mapeamento da FK de CategoriaId com a PK Id da tabela de Livros
            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Livros)
                .HasForeignKey(x => x.CategoriaId);

            builder.HasData(
                GerarLivro("Percy Jackson 1", "9781423121701", 400, 42.60m, 1),
                GerarLivro("Blockchain for Babies", "1492680788", 24, 45.55m, 3),
                GerarLivro("Clean Code", "9780132350884", 431, 371.69m, 3),
                GerarLivro("Querido Johnny", "8580417716", 256, 20.90m, 2));
        }

        private Livro GerarLivro(string nome, string isbn, ushort quantidadePaginas, decimal preco, int categoriaId)
        {
            return new Livro
            {
                Id = ++id,
                Titulo = nome,
                CategoriaId = categoriaId,
                Preco = preco,
                Isbn = isbn,
                QuantidadePaginas = quantidadePaginas
            };
        }
    }
}
