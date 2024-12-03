namespace Solare.Business.Models
{
    public class Simulacao : Entity
    {
        public Guid ClienteId { get; set; }

        public string Nome { get; set; }
        public TipoImovel TipoImovel { get; set; }
        public double OrcamentoMaximo { get; set; }
        public double ConsumoMedioMensal { get; set; }
        public double ValorMedioContaEnergia { get; set; }
        public int AnosPermanencia { get; set; }
        public double EspacoTotalInstalacao { get; set; }

        //EF Relations
        public Cliente Cliente { get; set; }
    }
}
