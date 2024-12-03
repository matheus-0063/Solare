namespace Solare.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public EnderecoSimulacao EnderecoSimulacao { get; set; }
        public bool Ativo { get; set; }

        //EF Relations
        public IEnumerable<Simulacao> Simulacoes { get; set; }
    }
}
