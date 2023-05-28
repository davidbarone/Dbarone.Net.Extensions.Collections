# Dbarone.Net.Extensions.Collections

**NOTE: THIS REPOSITORY HAS BEEN ARCHIVED AND IS NO LONGER ACTIVELY MAINTAINED. REFER TO  https://github.com/davidbarone/Dbarone.Net.Extensions FOR ACTIVE DEVELOPMENT.**

A library of .NET extension methods for working with arrays, hash tables, dictionaries and collections.

## Extension Methods

| Method                                                                         | Description                                               |
| ------------------------------------------------------------------------------ | --------------------------------------------------------- |
| `IEnumerable<T> Sample<T>(IEnumerable<T>, int)`                                | Returns a statistically random subset of data.            |
| `IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>>)` | Creates a cartesian product of n sequences.               |
| `T[] Splice<T>(T[], long, long?)`                                              | Splices an array.                                         |
| `IEnumerable<object> Union(object, params object[])`                           | Creates a collection from a number of individual objects. |
