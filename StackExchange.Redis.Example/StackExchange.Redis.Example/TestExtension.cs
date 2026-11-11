namespace StackExchange.Redis.Example;

public static class TestExtension
{
    extension<TSource>(IEnumerable<TSource> source)
    {
        public bool IsEmpty => !source.Any();
    }
}