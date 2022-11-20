using ProwayTests.Builders.Entities;
using Repository.Entities;
using Service.ViewModels.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwayTests.Builders.ViewModels.Categorias
{
    internal class CategoriaIndexViewModelBuilder
    {
        private int _Id;
        private string _nome;

        public CategoriaIndexViewModel Construir()
        {
            return new CategoriaIndexViewModel
            {
                Id = _Id,
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
            _Id = id;
            return this;
        }
    }
}
