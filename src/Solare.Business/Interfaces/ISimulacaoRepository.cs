using Solare.Business.Models;

namespace Solare.Business.Interfaces
{
    public interface ISimulacaoRepository : IRepository<Simulacao>
    {
        Task<IEnumerable<Simulacao>> ObterSimulacaoPorCliente(Guid clienteId);
        Task<IEnumerable<Simulacao>> ObterSimulacoesClientes();
        Task<Simulacao> ObterSimulacoesCliente(Guid id);
    }
}
