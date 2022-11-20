using FluentAssertions;
using Newtonsoft.Json;
using ProwayTests.Builders.Entities;
using Repository.Entities;
using Service.ViewModels.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProwayTests.Integrations.Controllers
{
    public class LivroControllerTests : BaseIntegration
    {
        [Fact]
        public async Task Test_Index()
        {
            // Arrange
            CreateEntity(
                new CategoriaBuilder().ComId(1).ComNome("Documentário").Construir(),
                new CategoriaBuilder().ComId(2).ComNome("Ação").Construir(),
                new CategoriaBuilder().ComId(3).ComNome("Suspense").Construir()
            );

            var livrosBancoDados = new List<Livro>
            {
                new LivroBuilder()
                    .ComId(1)
                    .ComTitulo("HP 1").ComPreco(300.90m).ComCategoriaId(1).Construir(),
                new LivroBuilder()
                    .ComId(2).ComTitulo("Java for seniors")
                    .ComPreco(1900.00m).ComCategoriaId(3).Construir(),
                new LivroBuilder()
                    .ComId(3).ComTitulo("C# for seniors")
                    .ComPreco(29.00m).ComCategoriaId(2).Construir()
            };

            CreateEntity(livrosBancoDados.ToArray());

            // Act
            var response = await _client.GetAsync("/Livros");

            // Assert
            // Validando que a requisição foi executada com sucesso
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Transforma o response (JSON) para lista de objetos, que permitirá validar
            var content = await response.Content.ReadAsStringAsync();
            var livros = JsonConvert.DeserializeObject<List<LivroIndexViewModel>>(content);

            // TODO: validar a lista de livros retoranda
            livros.Should().HaveCount(3);

            ValidateLivros(livros, livrosBancoDados.OrderByDescending(x => x.Id).ToList());
        }

        [Fact]
        public async Task Test_Cadastrar()
        {
            // Arrange
            var livroCadastrarViewModel = new LivroCadastrarViewModel
            {
                CategoriaId = 1,
                Isbn = "200000",
                Preco = 300,
                QuantidadePaginas = 100,
                Titulo = "Título teste"
            };
            // Objeto para string (JSON)
            var dado = JsonConvert.SerializeObject(livroCadastrarViewModel);
            // Dado que será enviado para o endpoint
            var content = new StringContent(dado, Encoding.UTF8, "application/json");

            // Act
            // Realizado o request para o endpoint de livros cadastrar método POST
            var response = await _client.PostAsync("/livros", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var conteudo = await response.Content.ReadAsStringAsync();
            // Validando que o endpoint retornou o id 1, novo registro persistido
            // por este endpoint de cadastro do livro
            var viewModelRetornada = JsonConvert
                .DeserializeObject<Livro>(conteudo);
            viewModelRetornada.Id.Should().Be(1);

            // Buscar no banco de dados para validar que os dados persistidos pelo
            // endpoint são os mesmos do viewModel enviado
            var livroPersistidoBancoDados = GetById<Livro>(1);

            ValidateLivro(livroPersistidoBancoDados, viewModelRetornada);
        }

        private void ValidateLivro(Livro? livroPersistidoBancoDados, 
            Livro viewModelRetornada)
        {
            livroPersistidoBancoDados.CategoriaId.Should()
                .Be(viewModelRetornada.CategoriaId);
            livroPersistidoBancoDados.Isbn.Should().Be(viewModelRetornada.Isbn);
            livroPersistidoBancoDados.QuantidadePaginas.Should().Be(
                viewModelRetornada.QuantidadePaginas);
            livroPersistidoBancoDados.Titulo.Should().Be(
                viewModelRetornada.Titulo);
            livroPersistidoBancoDados.Preco.Should().Be(
                viewModelRetornada.Preco);
        }

        private void ValidateLivros(
            List<LivroIndexViewModel>? livros,
            List<Livro> livrosBancoDados)
        {
            for (int i = 0; i < livrosBancoDados.Count; i++)
            {
                var livro = livros[i];
                var livroBancoDados = livrosBancoDados[i];

                ValidateLivro(livro, livroBancoDados);
            }
        }

        private void ValidateLivro(LivroIndexViewModel livro, Livro livroBancoDados)
        {
            livro.Id.Should().Be(livroBancoDados.Id);
            livro.Titulo.Should().Be(livroBancoDados.Titulo);
            livro.Preco.Should().Be(livroBancoDados.Preco);
            livro.Categoria.Should().Be(livroBancoDados.Categoria.Nome);
        }
    }
}
