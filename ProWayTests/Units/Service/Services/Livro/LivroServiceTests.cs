using NSubstitute;
using ProwayTests.Builders.Entities;
using ProwayTests.Builders.ViewModels.Categorias;
using ProwayTests.Builders.ViewModels.Livro;
using Repository.Entities;
using Repository.Repositories.Livros;
using Service.Services.Livros;
using Service.ViewModels.Livros;
using Xunit;

namespace ProwayTests.Units.Service.Services.Livro
{
    public class LivroServiceTests
    {
        private readonly ILivroRepository _livroRepository;
        private readonly ILivroService _livroService;

        public LivroServiceTests()
        {
            //substituicao da interface o que permitirá dizer qual será o comportamento dos metodos da interface
            _livroRepository = Substitute.For<ILivroRepository>();
            //instancia da classe que contém o método que desejamos testar
            _livroService = new LivrosService(_livroRepository);
        }

        [Fact]

        public void Test_Editar_Sem_Excecao()
        {
           // //Arrange
           // var livroUpdate = new LivroEditarViewModelBuilder()
           //     .ComId(10)
           //     .ComNome("Fazendo sozinho")
           //     .Construir();
           //
           // var LivroGetId = new LivroBuilder()
           //     .ComId(10)
           //     .ComNome("Fazendo Sozinho")
           //     .Construir();
           //
           // _categoriaRepository
           //     .GetById(Arg.Is(10))
           //     .Returns(categoriaGetId);
           //
           // //Act
           // _categoriaService.Alterar(categoriaUpdate);
           //
           // //Assert
           //
           // _categoriaRepository.Received(1).GetById(Arg.Is(10));
           //
           // _categoriaRepository
           //     .Received(1)
           //     .Update(Arg.Is<Categoria>(x => ValidaeCategoria(x, categoriaGetId)));
           //
           //

        }
    }
}
