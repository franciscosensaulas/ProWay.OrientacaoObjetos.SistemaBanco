using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Livros
{
    public class LivroIndexViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Preco { get; set; }

        public string Categoria { get; set; }
    }
}
