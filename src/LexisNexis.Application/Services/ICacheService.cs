namespace LexisNexis.Application.Services;

public interface ICacheService<T>
{
    IEnumerable<T>? Get(string key);
    void Set(string key, IEnumerable<T> data);
}