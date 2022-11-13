using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using ProWayTests.Builders.Entities;
using ProWayTests.Builders.ViewModels.Categorias;
using Repository.Entities;
using Repository.Repositories.Categorias;
using Service.Exceptions;
using Service.Services.Categorias;
using Service.ViewModels.Categorias;
using Xunit;

namespace ProWayTests.Units.Service.Services.Categorias
{
    public class CategoriaServiceTest
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;

        public CategoriaServiceTest()
        {
            // Substituição da interface o que permitirá dizer qual será o 
            // comportamento dos métodos da interface
            _categoriaRepository = Substitute.For<ICategoriaRepository>();
            // Instancia da classe que contém o método que desejamos testar
            _categoriaService = new CategoriaService(_categoriaRepository);
        }

        [Theory]
        [InlineData("    Paulo da Silva João   ")]
        [InlineData("    Paulo")]
        [InlineData("Paulo da Silva João    ")]
        [InlineData("Paulo da Silva João")]
        public void Test_Cadastrar(string nome)
        {
            // Arrange
            var (categoriaCadastrarViewModel, 
                categoriaEsperada, 
                categoriaIndexViewModelEsperada) = ConstruirEntidadeViewModels(nome);

            // Act
            var viewModel = _categoriaService.Cadastrar(categoriaCadastrarViewModel);

            // Assert
            _categoriaRepository
                .Received(1)
                .Add(Arg.Is<Categoria>(
                    x => ValidateCategoria(x, categoriaEsperada)));

            // Validar o retorno do método cadastrar, garantindo que a
            // informação ñ foi modificada no método Cadastrar, do que 
            // era esperado
            ValidarCategoriaIndexViewModel(viewModel, categoriaIndexViewModelEsperada);
        }

        [Fact]
        public void Test_Apagar()
        {
            // Arrange
            var idCategoria = 10;

            var categoria = new Categoria
            {
                Id = 10,
                Nome = "Suspense"
            };
            // Quando a categoriaRepository receber um parâmetro 10
            // no método GetById irá retornar o objeto categoria
            _categoriaRepository
                .GetById(Arg.Is(10))
                .Returns(categoria);

            // Act
            _categoriaService.Apagar(idCategoria);

            // Assert
            // Garantia de o método remover foi chamado com os dados 
            // Retornados pelo GetById, validando que não foram alterados
            _categoriaRepository
                .Received(1)
                .Remove(Arg.Is<Categoria>(x =>
                    x.Nome == "Suspense" &&
                    x.Id == 10 &&
                    x.Livros == null));
        }

        [Fact]
        public void Test_Apagar_Sem_Categoria()
        {
            // Arrange
            var id = 3;

            _categoriaRepository
                .GetById(Arg.Is(3))
                .ReturnsNull();

            // Act
            Action action = () => _categoriaService.Apagar(id) ;

            // Assert
            action.Should().Throw<NotFoundException>()
              .WithMessage("categoria not found with id 3");

            _categoriaRepository.Received(1)
                .GetById(Arg.Is(3));

            _categoriaRepository.DidNotReceive()
                .Remove(Arg.Is<Categoria>(x => x == null));
        }

        [Fact]
        public void Test_ObterTodos()
        {
            // Arrange
            var categorias = new List<Categoria>
            {
                new CategoriaBuilder().ComNome("Ação").Construir(),
                new CategoriaBuilder().ComNome("Suspense").Construir(),
                new CategoriaBuilder().ComNome("Poesia").Construir(),
            };

            _categoriaRepository.GetAll().Returns(categorias);

            // Act
            var categoriaIndexViewModels = _categoriaService.ObterTodos();

            // Assert
            ValidateCategoriaIndexViewModels(categoriaIndexViewModels, categorias);
        }

        private void ValidateCategoriaIndexViewModels(
            List<CategoriaIndexViewModel> categoriaIndexViewModels, 
            List<Categoria> categoriasEsperadas)
        {
            //categoriaIndexViewModels.Count.Should().Be(categoriasEsperadas.Count);
            categoriaIndexViewModels.Should().HaveSameCount(categoriasEsperadas);

            for(var i = 0; i < categoriasEsperadas.Count; i++)
            {
                var categoriaIndexViewModel = categoriaIndexViewModels[i];
                var categoriaEsperada = categoriasEsperadas[i];

                ValidateCategoriaIndexViewModel(categoriaIndexViewModel, categoriaEsperada);
            }
        }

        private void ValidateCategoriaIndexViewModel(
            CategoriaIndexViewModel categoriaIndexViewModel, 
            Categoria categoriaEsperada)
        {
            categoriaIndexViewModel.Id.Should().Be(categoriaEsperada.Id);
            categoriaIndexViewModel.Nome.Should().Be(categoriaEsperada.Nome);
        }

        private bool ValidateCategoria(
            Categoria categoria,
            Categoria categoriaEsperada)
        {
            categoria.Id.Should().Be(categoriaEsperada.Id);
            categoria.Nome.Should().Be(categoriaEsperada.Nome);

            return true;
        }

        public void ValidarCategoriaIndexViewModel(
            CategoriaIndexViewModel viewModel,
            CategoriaIndexViewModel viewModelEsperada)
        {
            viewModel.Id.Should().Be(viewModelEsperada.Id);
            viewModel.Nome.Should().Be(viewModelEsperada.Nome);
        }

        private (
            CategoriaCadastrarViewModel,
            Categoria,
            CategoriaIndexViewModel) ConstruirEntidadeViewModels(string nome)
        {
            var categoriaCadastrarViewModel = new CategoriaCadastrarViewModelBuilder()
                .ComNome(nome)
                .Construir();

            var categoriaEsperada = new CategoriaBuilder()
                .ComNome(categoriaCadastrarViewModel.Nome.Trim())
                .Construir();

            var categoriaIndexViewModelEsperada = new CategoriaIndexViewModelBuilder()
                .ComNome(categoriaCadastrarViewModel.Nome.Trim())
                .Construir();

            return (
                categoriaCadastrarViewModel, 
                categoriaEsperada,
                categoriaIndexViewModelEsperada);
        }
    }
}



// Imc
// CalcularImc(double altura, double peso){
// var imc = peso / (altura * altura);
// var status = _imcService.ObterStatus(imc);
// return "Obesidade II";
// }
// peso  = 100
// altura = 1.70
// imc => 34,60

// _imcService.ObterStatus(Arg.Is(34.60)).Returns("Sobrepreso");

// Act
// var status = CalcularImc(altura, peso);
// 
// status.Should().Be("Sobrepreso");



