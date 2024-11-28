using Solare.Business.Interfaces;
using Solare.Business.Models;
using Solare.Data.Context;

namespace Solare.Data.Repository
{
    public class SimulacaoRepository : Repository<Simulacao>, ISimulacaoRepository
    {
        public SimulacaoRepository(SolareDBContext context) : base(context) { }

    }
}
