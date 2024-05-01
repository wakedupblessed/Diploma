using System.Linq.Expressions;
using Diploma.Domain.Common;

namespace Diploma.Application.Contracts.Persistence;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAsync();
    Task<TEntity?> GetByIdAsync(string id);
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}