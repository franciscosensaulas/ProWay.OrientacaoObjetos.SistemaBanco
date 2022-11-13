using Repository.Entities;

namespace ProWayTests.Builders.Entities
{
    internal class CategoriaBuilder
    {
        private int _id;
        private string _nome;
        private List<Livro> _livros;

        public Categoria Construir()
        {
            return new Categoria
            {
                Id = _id,
                Nome = _nome,
                Livros = _livros
            };
        }

        public CategoriaBuilder ComNome(string nome)
        {
            _nome = nome;

            return this;
        }

        public CategoriaBuilder ComId(int id)
        {
            _id = id;

            return this;
        }

        public CategoriaBuilder ComLivros(List<Livro> livros)
        {
            _livros = livros;

            return this;
        }
    }
}
