using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Livros
{
    public class LivroViewModel
    {
        public string Titulo { get; set; }
        public decimal? Preco { get; set; }
        public int? CategoriaId { get; set; }
        public ushort? QuantidadePaginas { get; set; }

    }
}
