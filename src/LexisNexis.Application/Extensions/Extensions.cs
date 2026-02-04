namespace LexisNexis.Application.Extensions;

public static class Extensions
{
    public static IEnumerable<T> Search<T>(this IEnumerable<T> source,
        string searchTerm,
        Func<T, string> predicate)
    {
        return source.Where(x =>
        {
            var value = predicate(x);
            
            return !string.IsNullOrEmpty(value) &&
                   value.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
        });
    }
}