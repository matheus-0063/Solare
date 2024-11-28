using Microsoft.EntityFrameworkCore;
using Solare.Business.Interfaces;
using Solare.Business.Models;
using Solare.Data.Context;

namespace Solare.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SolareDBContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking().FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}
