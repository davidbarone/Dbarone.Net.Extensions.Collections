namespace Dbarone.Net.Extensions.Collections;
public static class CollectionsExtensions
{
    /// <summary>
    /// Returns a statistically random subset of data.
    /// </summary>
    /// <typeparam name="T">The type of the data element.</typeparam>
    /// <param name="data">The data to provide a sample from.</param>
    /// <param name="sampleSize">The sample size.</param>
    /// <returns>A random sample of the data.</returns>
    public static IEnumerable<T> Sample<T>(this IEnumerable<T> data, int sampleSize)
    {
        List<int> sampleIndexes = new List<int>();
        int dataSize = data.Count();

        // Sample size cannot be greater than population / data size
        if (sampleSize > dataSize)
        {
            sampleSize = dataSize;
        }

        for (int i = 0; i < sampleSize; i++)
        {
            while (true)
            {
                var rand = new Random().Next(dataSize);
                if (!sampleIndexes.Contains(rand))
                {
                    sampleIndexes.Add(rand);
                    break;
                }
            }
        }

        var sample = sampleIndexes.Select(i => data.ElementAt(i));
        return sample;
    }

    /// <summary>
    /// Creates a cartesian product of n sequences.
    /// The resulting sequence contains all combinations.
    /// Each element has n items in the sequence.
    /// 
    /// Taken from: https://ericlippert.com/2010/06/28/computing-a-cartesian-product-with-linq/
    /// </summary>
    /// <typeparam name="T">The type of the element</typeparam>
    /// <param name="sequences">The data.</param>
    /// <returns>The cartesian product of elements.</returns>
    public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
    {
        IEnumerable<IEnumerable<T>> emptyProduct =
          new[] { Enumerable.Empty<T>() };
        return sequences.Aggregate(
          emptyProduct,
          (accumulator, sequence) =>
            from accseq in accumulator
            from item in sequence
            select accseq.Concat(new[] { item }));
    }

    /// <summary>
    /// Splices an array.
    /// </summary>
    /// <typeparam name="T">The element type of the array.</typeparam>
    /// <param name="source">The source array to splice.</param>
    /// <param name="start">The start element to splice elements from.</param>
    /// <param name="number">The number of elements to remove.</param>
    /// <returns>An array with the specified elements spliced from it.</returns>
    public static T[] Splice<T>(this T[] source, long start, long? number = null)
    {
        var len = source.Length;
        var c = len - start;
        if (number.HasValue)
            c = number.Value;
        T[] result = new T[c];

        while (c > 0)
        {
            result[c - 1] = source[start + c - 1];
            c--;
        }
        return result;
    }
}
