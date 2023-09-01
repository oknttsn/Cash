namespace Cash.Business.Abstract;

public interface IBaseService<T> where T : class
{
    void TAdd(T entity);
    void TUpdate(T entity);
    void TDelete(T entity);
    T TGetById(Guid id);
    List<T> TGetAll();
}
