namespace Solare.Business.Models
{
    public class Produto : Entity
    {
        public Guid FornecedorId { get; set; }

        public string Nome { get; set; }
        public TiposProduto TipoProduto { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        //Estrutura
        public double? DimensaoEmMtQuadrado { get; set; }

        //Modulo
        public double? Eficiencia { get; set; }

        //Inversor e Modulo
        public double? Potencia { get; set; }
        public double? Corrente { get; set; }
        public double? Tensao { get; set; }
        public int? Saida { get; set; }


        //EF Relations  
        public Fornecedor Fornecedor { get; set; }
    }
}
