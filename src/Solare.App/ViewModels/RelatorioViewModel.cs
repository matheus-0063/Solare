using System.ComponentModel.DataAnnotations;

namespace Solare.App.ViewModels
{
    public class RelatorioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid SimulacaoId { get; set; }
        public string NomeCliente { get; set; }
        public string NomeSimulacao { get; set; }
        public int QuantidadeModulos { get; set; }
        public int QuantidadeInversores { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public double ValorTotalProdutos { get; set; }
        public double ValorInstalacao { get; set; }
        public double ValorTotal { get; set; }
    }
}
