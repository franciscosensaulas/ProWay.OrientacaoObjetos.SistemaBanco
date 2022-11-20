using ProwayTests.Builders.ViewModels.Categorias;
using Service.ViewModels.Categorias;
using Service.ViewModels.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwayTests.Builders.ViewModels.Livro
{
    internal class LivroEditarViewModelBuilder
    {
        private int _Id;
        private string _titulo { get; set; }
        private decimal? _preco { get; set; }
        private int? _categoriaId { get; set; }
        private ushort? _quantidadePaginas { get; set; }

        public LivroEditarViewModel Construir()
        {
            return new LivroEditarViewModel
            {
                Id = _Id,
                Titulo = _titulo,
                Preco = _preco,
                CategoriaId = _categoriaId,
                QuantidadePaginas = _quantidadePaginas
            };
        }
        public LivroEditarViewModelBuilder ComId(int id)
        {
            _Id = id;
            return this;
        }

        public LivroEditarViewModelBuilder ComTitulo(string titulo)
        {
            _titulo = titulo;
            return this;
        }

        public LivroEditarViewModelBuilder ComPreco(decimal preco)
        {
            _preco = preco;
            return this;
        }
        public LivroEditarViewModelBuilder ComTitulo(int categoriaId)
        {
            _categoriaId = categoriaId;
            return this;
        }
        public LivroEditarViewModelBuilder ComTitulo(ushort quantidadePaginas)
        {
            _quantidadePaginas = quantidadePaginas;
            return this;
        }
    }
}
