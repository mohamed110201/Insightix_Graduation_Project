namespace Graduation_Project.Extenstions;

public static class EnumerableExtensions
{

    public static void Print<T>(this IEnumerable<T> enumerable)
    {
        foreach (var item in enumerable)
        {
            Console.WriteLine(item);
        }
    }
}