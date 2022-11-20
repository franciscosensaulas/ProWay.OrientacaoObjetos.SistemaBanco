using Service.ViewModels.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwayTests.Builders.ViewModels.Categorias
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
