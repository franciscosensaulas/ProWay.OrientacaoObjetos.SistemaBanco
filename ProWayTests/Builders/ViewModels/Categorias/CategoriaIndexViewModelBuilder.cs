using Service.ViewModels.Categorias;

namespace ProWayTests.Builders.ViewModels.Categorias
{
    internal class CategoriaIndexViewModelBuilder
    {
        private int _id;
        private string _nome;

        public CategoriaIndexViewModel Construir()
        {
            return new CategoriaIndexViewModel
            {
                Id = _id,
                Nome = _nome,
            };
        }

        public CategoriaIndexViewModelBuilder ComNome(string nome)
        {
            _nome = nome;

            return this;
        }

        public CategoriaIndexViewModelBuilder ComId(int id)
        {
            _id = id;

            return this;
        }
    }
}
