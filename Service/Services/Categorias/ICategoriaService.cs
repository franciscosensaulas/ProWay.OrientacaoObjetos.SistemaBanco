using Service.ViewModels.Categorias;
using Service.ViewModels.Livros;

namespace Service.Services.Categorias
{
    public interface ICategoriaService
    {
        // CRUD
        CategoriaIndexViewModel? ObterPorId(int id);
        List<CategoriaIndexViewModel> ObterTodos();
        CategoriaIndexViewModel Cadastrar(CategoriaCadastrarViewModel viewModel);
        void Alterar(CategoriaEditarViewModel viewModel);
        void Apagar(int id);
    }
}