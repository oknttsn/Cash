using Cash.Business.Abstract;
using Cash.DataAccess.Concrate;
using Cash.Entity.Concrate;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;
using System.Linq.Expressions;

namespace Cash.Business.Concrete;

public class SqlRepository<TEntity> : ISQLRepository<TEntity> where TEntity : class
{
    private Context Context { get; }
    private DbSet<TEntity> Items { get; }
    public SqlRepository(Context context)
    {
        Context = context;
        Items = Context.Set<TEntity>();
    }
    Type IQueryable.ElementType => ((IQueryable<TEntity>)Items).ElementType;

    Expression IQueryable.Expression => ((IQueryable<TEntity>)Items).Expression;

    IQueryProvider IQueryable.Provider => ((IQueryable<TEntity>)Items).Provider;

    IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() => ((IEnumerable<TEntity>)Items).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<TEntity>)Items).GetEnumerator();

    public void Add(TEntity entity) => Items.Add(entity);
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) => await Items.AddAsync(entity, cancellationToken);
    public void AddRange(IEnumerable<TEntity> entities) => Items.AddRange(entities);
    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken) => await Items.AddRangeAsync(entities, cancellationToken);
    public void Update(TEntity entity) => Items.Update(entity);
    public void Remove(TEntity entity) => Items.Remove(entity);
    public void RemoveRange(IEnumerable<TEntity> entities) => Items.RemoveRange(entities);
    public Task SaveChangesAsync() => Context.SaveChangesAsync();

    public async Task<IEnumerable<TEntity>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken) => await Items.AsNoTracking().Where(x => ids.Contains((x as BaseEntity).Id)).ToListAsync(cancellationToken);

    public async Task<IEnumerable<TEntity>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] expression)
    {
        var query = Items.AsNoTracking().Where(x => ids.Contains((x as BaseEntity).Id));
        query = expression.Aggregate(query, (current, include) => current.Include(include));
        return await query.ToListAsync(cancellationToken);
    }

    public async Task RemoveAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        var item = await Items.FirstAsync(predicate, cancellationToken);
        Items.Remove(item);
    }
}