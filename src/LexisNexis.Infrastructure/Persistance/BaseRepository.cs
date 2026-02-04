using LexisNexis.Application.Repositories;
using LexisNexis.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace LexisNexis.Infrastructure.Persistance;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly List<T> _entities;
    private readonly ILogger<T> _logger;
        
    public BaseRepository(ILogger<T> logger)
    {
        _entities = new List<T>();
        _logger = logger;
    }

    public async Task Insert(T entity)
    {
        _entities.Add(entity);
        
        await Task.CompletedTask;
    }

    public T Update(T entity)
    {
        var result = GetById(entity.Id);
        var index = _entities.IndexOf(result);
            
        _entities[index] = entity;

        return entity;
    }

    public T GetById(Guid id)
    {
        var result = _entities.FirstOrDefault(x => x.Id == id);

        if (result == null)
        {
            _logger.LogError("Not found");
                
            throw new Exception("Not found");
        }
            
        return result;
    }

    public IEnumerable<T> GetAll()
    {
        return _entities;
    }

    // public IEnumerable<T>  Search(Func<T, bool> predicate)
    // {
    //     return _entities.Where(predicate);
    // }
        
    public async Task Delete(Guid id)
    {
        _entities.Remove(_entities.FirstOrDefault(x => x.Id.Equals(id)));
        
        await Task.CompletedTask;
    }
}
