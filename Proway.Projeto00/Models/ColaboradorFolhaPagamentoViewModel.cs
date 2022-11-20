using System.ComponentModel.DataAnnotations;

namespace Proway.Projeto00.Models
{
    public class ColaboradorFolhaPagamentoViewModel
    {
        [Range(0, double.MaxValue,ErrorMessage = "Campo Quantidade de horas Trabalhadas dever ser entre {1} e {2}")]
        [Required(ErrorMessage = "Campo Valor Hora deve ser informado")]
        [Display(Name = "Valor Hora")]
        public decimal? ValorHora { get; set; }

        [Range(0, 100, ErrorMessage="Campo Quantidade horas extras dever ser entre {1} e {2}")]
        [Required(ErrorMessage = "Campo Quantidade de horas Extras deve ser informado")]
        [Display(Name = "Quantidade de horas Extras")]
        public int? QuantidadeHoraExtra { get; set; }
        
        [Range(0, 220, ErrorMessage= "Campo Quantidade de horas Trabalhadas dever ser entre {1} e {2}")]
        [Required(ErrorMessage = "Campo Quantidade de horas Trabalhadas deve ser informado")]
        [Display(Name = "Quantidade de horas Trabalhadas")]
        public int? HorasTrabalhadas { get; set; }

        [Required(ErrorMessage = "Campo Data da Contratação deve ser informado")]
        [Display(Name = "Data da Contratação")]
        public DateTime? DataContratacao { get; set; }

        [MinLength(3, ErrorMessage= "Campo nome deve conter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage= "Campo nome deve conter no maximo {1} caracteres")]
        [Required(ErrorMessage =$"Campo {nameof(Nome)} deve ser informado")]
        [Display(Name = nameof(Nome))]
        public String? Nome { get; set; }

        [Required(ErrorMessage = "Campo Cargo deve ser informado")]
        [Display(Name = "Função")]
        public int? Cargo { get; set; }

        public decimal CalcularSalarioBruto() => ValorHora.GetValueOrDefault() * HorasTrabalhadas.GetValueOrDefault();

        public decimal CalcularSalarioliquido()
        {
            var bonus = CalcularBonus();
            var horasExtra = CalcularHorasExtras();
            var salarioBruto = CalcularSalarioBruto();

            return bonus + horasExtra + salarioBruto;
        }

        public decimal CalcularBonus()
        {
            var salarioBruto = CalcularSalarioBruto();

            if (PossuiAnosCasa(10))
                return salarioBruto * 1.20m;

            if (PossuiAnosCasa(5))
                return salarioBruto * 1.1m;

            return salarioBruto * 1.05m;
        }

        public decimal CalcularHorasExtras() => ValorHora.GetValueOrDefault() * QuantidadeHoraExtra.GetValueOrDefault() * 1.70m;

        private bool PossuiAnosCasa(int anosCasa)
        {
            var dataAnosCasa = DateTime.Today.AddYears(anosCasa * -1);

            return DataContratacao.GetValueOrDefault() < dataAnosCasa;
        }
    }
}
