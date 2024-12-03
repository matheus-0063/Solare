using Solare.Business.Models;

namespace Solare.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteEnderecoSimulacao(Guid id);
        Task<Cliente> ObterClienteSimulacoesEndereco(Guid id);
    }
}
