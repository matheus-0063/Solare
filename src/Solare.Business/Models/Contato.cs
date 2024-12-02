namespace Solare.Business.Models
{
    public class Contato : Entity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string  Email { get; set; }
        public TipoContato TipoContato { get; set; }
        public string? Mensagem { get; set; }
    }
}
