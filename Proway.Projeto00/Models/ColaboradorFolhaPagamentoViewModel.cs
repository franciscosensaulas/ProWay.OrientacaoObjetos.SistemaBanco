using System.ComponentModel.DataAnnotations;

namespace Proway.Projeto00.Models
{
    public class ColaboradorFolhaPagamentoViewModel
    {
        [Range(0, double.MaxValue, ErrorMessage = "Campo valor hora deve ser entre {1} e {2}")]
        [Required(ErrorMessage = "Campo valor hora deve ser preenchido")]
        [Display(Name = "Valor hora")]
        public decimal? ValorHora { get; set; }

        [Range(0, 100, ErrorMessage = "Campo quantidade horas extras deve ser entre {1} e {2}")]
        [Required(ErrorMessage = "Campo quantidade horas extras deve ser preenchido")]
        [Display(Name = "Quantidade horas extras")]
        public int? QuantidadeHoraExtra { get; set; }

        [Range(10, 220, ErrorMessage = "Campo horas trabalhadas deve ser entre {1} e {2}")]
        [Required(ErrorMessage = "Campo Horas trabalhadas deve ser preenchido")]
        [Display(Name = "Horas trabalhadas")]
        public int? HorasTrabalhadas { get; set; }

        [Required(ErrorMessage = "Campo Data contratação deve ser preenchido")]
        [Display(Name = "Data contratação")]
        public DateTime? DataContratacao { get; set; }

        [MinLength(3, ErrorMessage = "Campo nome deve conter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "Campo nome deve conter no máximo {1} caracteres")]
        [Required(ErrorMessage = $"Campo {nameof(Nome)} deve ser preenchido")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Cargo deve ser preenchido")]
        [Display(Name = "Cargo")]
        public int? Cargo { get; set; }

        //public decimal CalcularSalarioBruto()
        //{
        //    return ValorHora.GetValueOrDefault() * HorasTrabalhadas.GetValueOrDefault();
        //}

        // Expression method
        public decimal CalcularSalarioBruto() =>
            ValorHora.GetValueOrDefault() * HorasTrabalhadas.GetValueOrDefault();

        public decimal CalcularSalarioLiquido()
        {
            var bonus = CalcularBonus();
            var horaExtra = CalcularHorasExtras();
            var salarioBruto = CalcularSalarioBruto();

            return bonus + horaExtra + salarioBruto;
        }

        public decimal CalcularBonus()
        {
            var salarioBruto = CalcularSalarioBruto();

            if (PossuiAnosCasa(10))
                return salarioBruto * 1.2m;


            if (PossuiAnosCasa(5))
                return salarioBruto * 1.1m;

            return salarioBruto * 1.05m;
        }

        public decimal CalcularHorasExtras() =>
            ValorHora.GetValueOrDefault() * QuantidadeHoraExtra.GetValueOrDefault() * 1.70m;

        private bool PossuiAnosCasa(int anosCasa)
        {
            var dataAnosCasa = DateTime.Today.AddYears(anosCasa * -1);

            return DataContratacao.GetValueOrDefault() < dataAnosCasa;
        }
    }
}
