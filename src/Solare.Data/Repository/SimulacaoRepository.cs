using Solare.Business.Interfaces;
using Solare.Business.Models;
using Solare.Data.Context;

namespace Solare.Data.Repository
{
    public class SimulacaoRepository : Repository<Simulacao>, ISimulacaoRepository
    {
        public SimulacaoRepository(SolareDBContext context) : base(context) { }

        public Task<IEnumerable<Simulacao>> ObterSimulacaoPorCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<Simulacao> ObterSimulacoesCliente(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Simulacao>> ObterSimulacoesClientes()
        {
            throw new NotImplementedException();
        }
    }
}
