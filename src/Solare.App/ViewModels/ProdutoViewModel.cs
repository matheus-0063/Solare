using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Solare.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(200, ErrorMessage = "O campo {0} pprecisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Tipo")]
        public int TipoProduto { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public double Valor { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [DisplayName("Dimensão do produto")]
        public double DimensaoEmMtQuadrado { get; set; }

        [DisplayName("Eficiência")]
        public double Eficiencia { get; set; }

        [DisplayName("Potência")]
        public double Potencia { get; set; }

        public double Corrente { get; set; }

        [DisplayName("Tensão")]
        public double Tensao { get; set; }

        public int Saida { get; set; }

        public FornecedorViewModel? Fornecedor { get; set; }
        public IEnumerable<FornecedorViewModel>? Fornecedores { get; set; }
    }
}
