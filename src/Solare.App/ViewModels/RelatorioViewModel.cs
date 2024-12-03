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
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public double TotalGasto { get; set; }
    }
}
