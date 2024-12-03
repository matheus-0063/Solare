using Microsoft.EntityFrameworkCore;
using Solare.Business.Interfaces;
using Solare.Business.Models;
using Solare.Data.Context;

namespace Solare.Data.Repository
{
    public class EnderecoSimulacaoRepository : Repository<EnderecoSimulacao>, IEnderecoSimulacaoRepository
    {
        public EnderecoSimulacaoRepository(SolareDBContext context) : base(context) { }
    }
}
