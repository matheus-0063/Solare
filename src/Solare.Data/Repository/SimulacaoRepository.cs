using Microsoft.EntityFrameworkCore;
using Solare.Business.Interfaces;
using Solare.Business.Models;
using Solare.Data.Context;

namespace Solare.Data.Repository
{
    public class SimulacaoRepository : Repository<Simulacao>, ISimulacaoRepository
    {
        public SimulacaoRepository(SolareDBContext context) : base(context) { }

        public async Task<IEnumerable<Simulacao>> ObterSimulacaoPorCliente(Guid id)
        {
            return await Buscar(s => s.ClienteId == id);
        }

        public async Task<Simulacao> ObterSimulacoesCliente(Guid id)
        {
            return await Db.Simulacoes
                .AsNoTracking()
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Simulacao>> ObterSimulacoesClientes()
        {
            return await Db.Simulacoes.AsNoTracking().Include(s => s.Cliente)
                .OrderBy(p => p.Nome).ToListAsync();
        }
    }
}
