using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Solare.App.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        public EnderecoSimulacaoViewModel? Endereco { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        public IEnumerable<SimulacaoViewModel>? Simulacoes { get; set; }
    }
}
