using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels.Categorias
{
    public abstract class CategoriaViewModel
    {
        [Required(ErrorMessage = "{0} é obrigatório")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string? Nome { get; set; }
    }
}
