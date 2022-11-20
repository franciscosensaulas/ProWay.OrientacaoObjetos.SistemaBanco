using Repository.Entities;
using Repository.Repositories.Categorias;
using Service.Exceptions;
using Service.ViewModels.Categorias;

namespace Service.Services.Categorias
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepositorio _categoriaRepository;

        public CategoriaService(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepository = categoriaRepositorio;
        }

        public void Alterar(CategoriaEditarViewModel viewModel)
        {
            var categoria = _categoriaRepository.GetById(viewModel.Id);

            if (categoria == null)
                throw new NotFoundException("categoria", viewModel.Id);

            categoria.Nome = viewModel.Nome.Trim();

            _categoriaRepository.Update(categoria);
        }

        public void Apagar(int id)
        {
            var categoria = _categoriaRepository.GetById(id);

            if (categoria == null)
                throw new NotFoundException("categoria", id);
                    
            _categoriaRepository.Remove(categoria);
        }

        public CategoriaIndexViewModel Cadastrar(CategoriaCadastrarViewModel viewModel)
        {
            var categoria = new Categoria
            {
                Nome = viewModel.Nome.Trim()
            };

            _categoriaRepository.Add(categoria);

            var categoriaIndexViewModel = new CategoriaIndexViewModel()
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };

            return categoriaIndexViewModel;
        }

        public CategoriaIndexViewModel? ObterPorId(int id)
        {
            var categoria = _categoriaRepository.GetById(id);

            return new CategoriaIndexViewModel
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
        }

        public List<CategoriaIndexViewModel> ObterTodos()
        {
            var categorias = _categoriaRepository.GetAll();

            var categoriasIndexViewModels = categorias.Select(x => new CategoriaIndexViewModel
            {
                Id = x.Id,
                Nome = x.Nome
            }).ToList();
            
            return categoriasIndexViewModels;
        }
    }
}
