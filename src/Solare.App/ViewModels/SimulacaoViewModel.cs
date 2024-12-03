using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Solare.App.ViewModels
{
    public class SimulacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Tipo Imóvel: ")]
        public int TipoImovel { get; set; }

        [DisplayName("Orçamento Maximo: ")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public double OrcamentoMaximo { get; set; }

        [DisplayName("Consumo Médio: ")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public double ConsumoMedioMensal { get; set; }

        [DisplayName("Valor Médio da Conta de Energia: ")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public double ValorMedioContaEnergia { get; set; }

        [DisplayName("Anos Permanencia: ")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int AnosPermanencia { get; set; }

        [DisplayName("Espaço em metros quadrados da instalação: ")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public double EspacoTotalInstalacao { get; set; }

        public ClienteViewModel? Cliente { get; set; }
        public IEnumerable<ClienteViewModel>? Clientes { get; set; }
    }
}
