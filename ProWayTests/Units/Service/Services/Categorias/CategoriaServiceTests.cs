using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using ProwayTests.Builders.Entities;
using ProwayTests.Builders.ViewModels.Categorias;
using Repository.Entities;
using Repository.Repositories.Categorias;
using Service.Exceptions;
using Service.Services.Categorias;
using Service.ViewModels.Categorias;
using System;
using Xunit;

namespace ProwayTests.Units.Service.Services.Categorias
{
    public class CategoriaServiceTests
    {
        private readonly ICategoriaRepositorio _categoriaRepository;
        private readonly ICategoriaService _categoriaService;

        public CategoriaServiceTests()
        {
            //substituicao da interface o que permitirá dizer qual será o comportamento dos metodos da interface
            _categoriaRepository = Substitute.For<ICategoriaRepositorio>();
            //instancia da classe que contém o método que desejamos testar
            _categoriaService = new CategoriaService(_categoriaRepository);
        }

        [Theory]
        [InlineData("     Pablo Da Silva João")]
        [InlineData("    Paulo")]
        [InlineData("Pablo Da Silva João          ")]
        [InlineData("Pablo Da Silva João")]
        public void Test_Cadastrar(string nome)
        {
            //Arrange
            var (categoriaCadastrarViewModel, categoriaEsperada, categoriaCadastrarViewModelEsperada) = ConstruirEntidadeViewModel(nome);

            //Act
            var categoriaIndexViewModel = _categoriaService.Cadastrar(categoriaCadastrarViewModel);

            //Assert

            _categoriaRepository
                .Received(1)
                .Add(Arg.Is<Categoria>(x => ValidaeCategoria(x, categoriaEsperada)));

            ValidarCategoriaIndexViewModel(categoriaIndexViewModel, categoriaCadastrarViewModelEsperada);

            categoriaIndexViewModel.Id.Should().Be(0);
            categoriaIndexViewModel.Nome.Should().Be(nome.Trim());
        }

        [Fact]
        public void Test_Alterar_Sem_Excecao()
        {
            //Arrange
            var categoriaUpdate = new CategoriaEditarViewModelBuilder()
                .ComId(10)
                .ComNome("Fazendo sozinho")
                .Construir();

            var categoriaGetId = new CategoriaBuilder()
                .ComId(10)
                .ComNome("Fazendo Sozinho")
                .Construir();

            _categoriaRepository
                .GetById(Arg.Is(10))
                .Returns(categoriaGetId);

            //Act
            _categoriaService.Alterar(categoriaUpdate);

            //Assert

            _categoriaRepository.Received(1).GetById(Arg.Is(10));

            _categoriaRepository
                .Received(1)
                .Update(Arg.Is<Categoria>(x => ValidaeCategoria(x, categoriaGetId)));

        }

        [Fact]
        public void Test_Alterar_Com_Excecao()
        {
            //Arrange
            var categoriaUpdate = new CategoriaEditarViewModelBuilder()
                .ComId(10)
                .ComNome("Fazendo sozinho")
                .Construir();

            _categoriaRepository
                .GetById(Arg.Is(10))
                .ReturnsNull();

            //Act
            Action action = () => _categoriaService.Alterar(categoriaUpdate);

            //Assert

            action.Should().ThrowExactly<NotFoundException>()
               .WithMessage("categoria not found with 10");

            _categoriaRepository.Received(1)
                .GetById(Arg.Is(10));

            _categoriaRepository.DidNotReceive()
                .Remove(Arg.Is<Categoria>(x => x == null));

        }

        [Fact]
        public void Test_Apagar()
        {
            //Arrange
            var idCategoria = 10;

            var categoria = new Categoria
            {
                Id = 10,
                Nome = "Suspense"
             };

            //Quando a categoriaRepository receber um parametro 10 no metodo getbyid irá retornar o objeto categoria.
            _categoriaRepository
                .GetById(Arg.Is(10))
                .Returns(categoria);

            //Act
            _categoriaService.Apagar(idCategoria);

            //Assert


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
            //Arrange
            var id = 3;

            _categoriaRepository.GetById(Arg.Is(3)).ReturnsNull();

            //Act
            Action action = () => _categoriaService.Apagar(id);

            //Assert

            action.Should().ThrowExactly<NotFoundException>()
                .WithMessage("categoria not found with 3");

            _categoriaRepository.Received(1)
                .GetById(Arg.Is(3));

            _categoriaRepository.DidNotReceive()
                .Remove(Arg.Is<Categoria>(x => x == null));
        }

        [Fact]
        public void Test_ObterTodos()
        {
            //arrange
            var categorias = new List<Categoria>
            {
                new CategoriaBuilder().ComNome("Acao").Construir(),
                new CategoriaBuilder().ComNome("Suspense").Construir(),
                new CategoriaBuilder().ComNome("Poesia").Construir()
            };

            _categoriaRepository.GetAll().Returns(categorias);

            //act
            var categoriaIndexViewModels = _categoriaService.ObterTodos();

            //Assert
            ValidateCategoriaIndexeViewModels(categoriaIndexViewModels, categorias);

        }

        private void ValidateCategoriaIndexeViewModels(List<CategoriaIndexViewModel> categoriaIndexViewModels, List<Categoria> categoriasEsperadas)
        {
            categoriaIndexViewModels.Count.Should().Be(categoriasEsperadas.Count);
            categoriaIndexViewModels.Should().HaveSameCount(categoriasEsperadas);

            for(var i = 0; i < categoriasEsperadas.Count; i++)
            {
                var categoriaIndexViewModel = categoriaIndexViewModels[i];
                var categoriasEsperada = categoriasEsperadas[i];

                ValidateCategoriaIndexViewModel(categoriaIndexViewModel, categoriasEsperada);
            }
        }

        private static void ValidateCategoriaIndexViewModel(CategoriaIndexViewModel categoriaIndexViewModel, Categoria categoriasEsperada)
        {
            categoriaIndexViewModel.Id.Should().Be(categoriasEsperada.Id);
            categoriaIndexViewModel.Nome.Should().Be(categoriasEsperada.Nome);
        }

        private bool ValidaeCategoria(
            Categoria categoria,
            Categoria categoriaEsperada)
        {
            categoria.Id.Should().Be(categoriaEsperada.Id);
            categoria.Nome.Should().Be(categoriaEsperada.Nome);

            return true;
        }

        public void ValidarCategoriaIndexViewModel(CategoriaIndexViewModel viewModel, CategoriaIndexViewModel viewModelEsperada)
        {
            viewModel.Id.Should().Be(viewModelEsperada.Id);
            viewModel.Nome.Should().Be(viewModelEsperada.Nome);
        }

        private (
            CategoriaCadastrarViewModel, 
            Categoria,
            CategoriaIndexViewModel) ConstruirEntidadeViewModel(string nome)
        {
            var categoriaCadastrarViewModel = new CategoriaCadastrarViewModelBuilder()
            .ComNome(nome)
            .Construir();

            var categoriaEsperada = new CategoriaBuilder()
                .ComNome(categoriaCadastrarViewModel.Nome.Trim())
                .Construir();

            var categoriaCadastrarViewModelEsperada = new CategoriaIndexViewModelBuilder()
                .ComNome(categoriaCadastrarViewModel.Nome.Trim())
                .Construir();

            return (categoriaCadastrarViewModel, categoriaEsperada, categoriaCadastrarViewModelEsperada);
        }
    }
}
