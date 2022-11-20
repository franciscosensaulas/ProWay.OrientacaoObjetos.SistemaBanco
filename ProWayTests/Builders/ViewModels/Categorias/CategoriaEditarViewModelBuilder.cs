using Service.ViewModels.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwayTests.Builders.ViewModels.Categorias
{
    internal class CategoriaEditarViewModelBuilder
    {
        private int _Id;
        private string _nome;

        public CategoriaEditarViewModel Construir()
        {
            return new CategoriaEditarViewModel
            {
                Id = _Id,
                Nome = _nome,
            };
        }

        public CategoriaEditarViewModelBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CategoriaEditarViewModelBuilder ComId(int id)
        {
            _Id = id;
            return this;
        }
    }
}
