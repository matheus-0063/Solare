using Solare.Business.Models;

namespace Solare.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteSimulacao(Guid id);
    }
}
