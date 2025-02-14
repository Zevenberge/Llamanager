namespace Llamanager.Web;

public static class AsyncEnumerableExtensions
{
    public static async IAsyncEnumerable<T> Tee<T>(this IAsyncEnumerable<T> values, Func<T, Task> sink)
    {
        await foreach(var value in values)
        {
            await sink(value);
            yield return value;
        }
    }
}