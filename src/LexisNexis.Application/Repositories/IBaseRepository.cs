namespace LexisNexis.Application.Repositories;

public interface IBaseRepository<T>
{
    Task Insert(T entity);
    T Update(T entity);
    T GetById(Guid id);
    IEnumerable<T> GetAll();
    //IEnumerable<T> Search(Func<T, bool> predicate);        
    Task Delete(Guid id);
}
