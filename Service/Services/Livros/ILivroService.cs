using Service.ViewModels.Livros;

namespace Service.Services.Livros
{
    public interface ILivroService
    {
        void Apagar(int id);
        LivroIndexViewModel Cadastrar(LivroCadastrarViewModel viewModel);
        void Editar(LivroEditarViewModel viewModel);
        LivroEditarViewModel ObterPorId(int id);
        List<LivroIndexViewModel> ObterTodos();
    }
}