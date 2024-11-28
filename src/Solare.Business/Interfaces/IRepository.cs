using Solare.Business.Models;
using System.Linq.Expressions;

namespace Solare.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate); //Busca alguma informação da entidade atraves de expressão lambda
        Task<int> SaveChanges(); // Ele retorna sempre um INT e que é o numero de linhas afetadas
    }
}
