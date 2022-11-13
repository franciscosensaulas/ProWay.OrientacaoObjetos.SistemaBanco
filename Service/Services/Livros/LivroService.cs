using Repository.Entities;
using Repository.Repositories.Categorias;
using Repository.Repositories.Livros;
using Service.Exceptions;
using Service.ViewModels.Livros;

namespace Service.Services.Livros
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LivroService(ILivroRepository livroRepository, ICategoriaRepository categoriaRepository)
        {
            _livroRepository = livroRepository;
            _categoriaRepository = categoriaRepository;
        }

        public LivroIndexViewModel Cadastrar(LivroCadastrarViewModel viewModel)
        {
            var livro = ConstruirLivro(viewModel);

            _livroRepository.Add(livro);

            return ConstruirLivroIndexViewModel(livro);
        }

        public List<LivroIndexViewModel> ObterTodos()
        {
            var livros = _livroRepository.GetAll();

            return livros
                .Select(x => new LivroIndexViewModel
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Preco = x.Preco,
                    Categoria = x.Categoria.Nome
                })
                .ToList();
        }

        public void Apagar(int id)
        {
            var livro = _livroRepository.GetById(id);

            if(livro == null)
                throw new NotFoundException(nameof(Livro), id);

            _livroRepository.Remove(livro);
        }

        public LivroEditarViewModel ObterPorId(int id)
        {
            var livro = _livroRepository.GetById(id);

            if (livro == null)
                throw new NotFoundException(nameof(Livro), id);

            return ConstruirLivroEditarViewModel(livro);
        }

        public void Editar(LivroEditarViewModel viewModel)
        {
            var livro = _livroRepository.GetById(viewModel.Id);

            if (livro == null)
                throw new NotFoundException(nameof(Livro), viewModel.Id);

            var categoria = _categoriaRepository.GetById(
                viewModel.CategoriaId.GetValueOrDefault());

            if (categoria == null) 
                throw new NotFoundException(nameof(Categoria), viewModel.CategoriaId
                    .GetValueOrDefault());

            livro.Titulo = viewModel.Titulo;
            livro.Preco = viewModel.Preco.GetValueOrDefault();
            livro.QuantidadePaginas = viewModel.QuantidadePaginas.GetValueOrDefault();
            livro.CategoriaId = viewModel.CategoriaId.GetValueOrDefault();

            _livroRepository.Update(livro);
        }

        private LivroEditarViewModel ConstruirLivroEditarViewModel(Livro livro) =>
            new LivroEditarViewModel
            {
                CategoriaId = livro.CategoriaId,
                Preco = livro.Preco,
                Id = livro.Id,
                QuantidadePaginas = livro.QuantidadePaginas,
                Titulo = livro.Titulo
            };

        private LivroIndexViewModel ConstruirLivroIndexViewModel(Livro livro)
        {
            return new LivroIndexViewModel
            {
                Id = livro.Id
            };
        }

        private Livro ConstruirLivro(LivroCadastrarViewModel viewModel)
        {
            return new Livro
            {
                CategoriaId = viewModel.CategoriaId.GetValueOrDefault(),
                Titulo = viewModel.Titulo,
                Isbn = viewModel.Isbn,
                Preco = viewModel.Preco.GetValueOrDefault(),
                QuantidadePaginas = viewModel.QuantidadePaginas.GetValueOrDefault(),
            };
        }
    }
}
