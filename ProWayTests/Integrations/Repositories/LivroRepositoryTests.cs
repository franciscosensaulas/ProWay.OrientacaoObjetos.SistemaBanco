using FluentAssertions;
using ProwayTests.Builders.Entities;
using Repository.Entities;
using Repository.Repositories.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProwayTests.Integrations.Repositories
{
    public class LivroRepositoryTests : BaseIntegration
    {
        private readonly ILivroRepository _livroRepository;

        public LivroRepositoryTests()
        {
            _livroRepository = GetService<ILivroRepository>();
        }

        [Fact]
        public async Task Test_GetAll()
        {
            // Arrange
            var categorias = GetCategorias();
            CreateEntity(categorias.ToArray());

            var livrosEsperados = GetLivros();
            CreateEntity(livrosEsperados.ToArray());

            // Act
            var livros = _livroRepository.GetAll();

            // Assert
            ValidateLivros(livros, livrosEsperados.OrderByDescending(x => x.Id).ToList());
        }

        private void ValidateLivros(List<Livro> livros, List<Livro> livrosEsperados)
        {
            livros.Should().HaveSameCount(livrosEsperados);

            for(var i = 0; i < livrosEsperados.Count; i++) 
            {
                var livro = livros[i];
                var livroEsperado = livrosEsperados[i];
                ValidateLivro(livro, livroEsperado);
            }
        }

        private void ValidateLivro(Livro livro, Livro livroEsperado)
        {
            livro.Id.Should().Be(livroEsperado.Id);
            livro.Titulo.Should().Be(livroEsperado.Titulo);
            livro.Preco.Should().Be(livroEsperado.Preco);
            livro.QuantidadePaginas.Should().Be(livroEsperado.QuantidadePaginas);
            livro.Isbn.Should().Be(livroEsperado.Isbn);
            livro.CategoriaId.Should().Be(livroEsperado.CategoriaId);

            ValidateCategoria(livro.Categoria, livroEsperado.Categoria);
        }

        private void ValidateCategoria(Categoria categoria, Categoria categoriaEsperada)
        {
            categoria.Id.Should().Be(categoriaEsperada.Id);
            categoria.Nome.Should().Be(categoriaEsperada.Nome);
        }

        private List<Livro> GetLivros()
        {
            return new List<Livro>
            {
                new LivroBuilder().ComId(1).ComTitulo("C#").ComIsbn("1 isbn").ComCategoriaId(1)
                    .ComPreco(11.11m).ComQuantidadePaginas(11).Construir(),
                new LivroBuilder().ComId(2).ComTitulo("Python").ComIsbn("2 isbn").ComCategoriaId(1)
                    .ComPreco(22.22m).ComQuantidadePaginas(22).Construir(),
                new LivroBuilder().ComId(3).ComTitulo("História da programação")
                    .ComIsbn("3 isbn").ComCategoriaId(2)
                    .ComPreco(33.33m).ComQuantidadePaginas(33).Construir()
            };
        }

        private List<Categoria> GetCategorias()
        {
            return new List<Categoria>
            {
                new CategoriaBuilder().ComId(1).ComNome("Programação").Construir(),
                new CategoriaBuilder().ComId(2).ComNome("História").Construir()
            };
        }
    }
}
