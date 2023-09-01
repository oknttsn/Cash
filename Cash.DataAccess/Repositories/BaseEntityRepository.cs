using Cash.DataAccess.Abstract;
using Cash.DataAccess.Concrate;

namespace Cash.DataAccess.Repositories;

public class BaseEntityRepository<T> : IBaseEntity<T> where T : class
{

    public void Add(T entity)
    {
        using var context = new Context();
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        using var context = new Context();
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }

    public List<T> GetAll()
    {
        using var context = new Context();
        return context.Set<T>().ToList();
    }

    public T GetById(Guid id)
    {
        using var context = new Context();
        return context.Set<T>().Find(id);
    }

    public void Update(T entity)
    {
        using var context = new Context();
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }
}
