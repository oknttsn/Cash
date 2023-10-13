using System.Collections;
using System.Linq.Expressions;

namespace Cash.Business.Abstract;

public interface ISQLRepository<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IQueryable
{
    void Add(TEntity entity);
    Task AddAsync(TEntity entity, CancellationToken cancellation);
    void AddRange(IEnumerable<TEntity> entities);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task RemoveAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    void RemoveRange(IEnumerable<TEntity> entities);
    Task SaveChangesAsync();
    /// <summary>
    /// Returns entity list that contains given ids.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    /// <summary>
    /// Returns entity list with given include expression that contains given ids.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="expression">This expression for include entity. Not use for where expressions</param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] expression);
}