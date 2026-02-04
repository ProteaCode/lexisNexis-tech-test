using LexisNexis.Application.Services;
using Microsoft.Extensions.Caching.Memory;

namespace LexisNexis.Infrastructure.Services;

public class CacheService<T> : ICacheService<T>
{
    //private readonly IMemoryCache _memoryCache;
    private readonly Dictionary<string, IEnumerable<T>> _cache = new();

    public CacheService(/*IMemoryCache memoryCache*/)
    {
        //_memoryCache = memoryCache;
    }

    public IEnumerable<T>? Get(string key)
    {
        if (_cache.TryGetValue(key, out var item))
        {
            return (IEnumerable<T>)item;
        }
        
        return null;
    }

    public void Set(string key, IEnumerable<T> data)
    {
        _cache[key] = data;
    }
}