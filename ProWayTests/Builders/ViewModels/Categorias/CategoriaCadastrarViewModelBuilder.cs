using Service.ViewModels.Categorias;

namespace ProWayTests.Builders.ViewModels.Categorias
{
    internal class CategoriaCadastrarViewModelBuilder
    {
        private string _nome;

        public CategoriaCadastrarViewModel Construir()
        {
            return new CategoriaCadastrarViewModel
            {
                Nome = _nome,
            };
        }

        public CategoriaCadastrarViewModelBuilder ComNome(string nome)
        {
            _nome = nome;

            return this;
        }
    }
}
