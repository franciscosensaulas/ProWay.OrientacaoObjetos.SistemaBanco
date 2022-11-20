using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwayTests.Builders.Entities
{
    internal class CategoriaBuilder
    {
        private int _Id;
        private string _nome;
        private List<Livro> _livros;

        public Categoria Construir()
        {
            return new Categoria
            {
                Id = _Id,
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
            _Id = id;
            return this;
        }

        public CategoriaBuilder ComLivros(List<Livro> livros)
        {
            _livros = livros;
            return this;
        }
    }
}
