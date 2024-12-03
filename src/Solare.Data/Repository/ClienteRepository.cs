using Microsoft.EntityFrameworkCore;
using Solare.Business.Interfaces;
using Solare.Business.Models;
using Solare.Data.Context;

namespace Solare.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SolareDBContext context) : base(context) { }

        public async Task<Cliente> ObterClienteEnderecoSimulacao(Guid id)
        {
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.EnderecoSimulacao)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> ObterClienteSimulacoesEndereco(Guid id)
        {
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.Simulacoes)
                .Include(c => c.EnderecoSimulacao)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
