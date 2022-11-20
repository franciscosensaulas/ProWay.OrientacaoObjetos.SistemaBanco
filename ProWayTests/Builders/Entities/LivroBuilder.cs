using Repository.Entities;

namespace ProwayTests.Builders.Entities
{
    internal class LivroBuilder
    {
        public int _id = 1;
        private string _titulo = "Livro";
        private int _categoriaId = 1;
        private decimal _preco = 100m;
        private ushort _quantidadePaginas = 10;
        private string _isbn = "11";
        
        public Livro Construir()
        {
            return new Livro
            {
                Id = _id,
                CategoriaId = _categoriaId,
                Isbn = _isbn,
                Titulo = _titulo,
                QuantidadePaginas = _quantidadePaginas,
                Preco = _preco,
            };
        }


        public LivroBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public LivroBuilder ComTitulo(string titulo)
        {
            _titulo = titulo;
            return this;
        }

        public LivroBuilder ComPreco(decimal preco)
        {
            _preco = preco;
            return this;
        }

        public LivroBuilder ComCategoriaId(int categoriaId)
        {
            _categoriaId = categoriaId;
            return this;
        }

        public LivroBuilder ComQuantidadePaginas(ushort quantidadePaginas)
        {
            _quantidadePaginas = quantidadePaginas;
            return this;
        }

        public LivroBuilder ComIsbn(string isbn)
        {
            _isbn = isbn;
            return this;
        }
    }
}
