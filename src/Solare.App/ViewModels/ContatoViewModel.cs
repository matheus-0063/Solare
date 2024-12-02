using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Solare.App.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome: ")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Telefone: ")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string Telefone { get; set; }

        [DisplayName("E-mail: ")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Email { get; set; }

        [DisplayName("Tipo de Contato: ")]
        public int TipoContato { get; set; }

        [DisplayName("Mensagem (Opcional): ")]
        public string? Mensagem { get; set; }
    }
}
