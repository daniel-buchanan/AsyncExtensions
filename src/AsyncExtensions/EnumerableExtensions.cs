using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.AsyncExtensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Converts a Task that returns an IEnumerable to a Task that returns a List.
    /// </summary>
    /// <param name="self">The Task containing an IEnumerable to convert to a List.</param>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <returns>A Task that, when completed, will contain a List containing all elements from the IEnumerable, or an empty List if the IEnumerable is null.</returns>
    public static Task<List<T>> ToListAsync<T>(this Task<IEnumerable<T>> self)
        => self.ContinueWith(t => t.Result?.ToList() ?? []);
    
    /// <summary>
    /// Converts a Task that returns an array to a Task that returns a List.
    /// </summary>
    /// <param name="self">The Task containing an array to convert to a List.</param>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <returns>A Task that, when completed, will contain a List containing all elements from the array, or an empty List if the array is null.</returns>
    public static Task<List<T>> ToListAsync<T>(this Task<T[]> self)
        => self.ContinueWith(t => t.Result?.ToList() ?? []);

    /// <summary>
    /// Converts a Task that returns an IEnumerable to a Task that returns an array.
    /// </summary>
    /// <param name="self">The Task containing an IEnumerable to convert to an array.</param>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <returns>A Task that, when completed, will contain an array containing all elements from the IEnumerable, or an empty array if the IEnumerable is null.</returns>
    public static Task<T[]> ToArrayAsync<T>(this Task<IEnumerable<T>> self)
        => self.ContinueWith(t => t.Result?.ToArray() ?? []);
    
    /// <summary>
    /// Converts a Task that returns a List to a Task that returns an array.
    /// </summary>
    /// <param name="self">The Task containing a List to convert to an array.</param>
    /// <typeparam name="T">The type of elements in the List.</typeparam>
    /// <returns>A Task that, when completed, will contain an array containing all elements from the List, or an empty array if the List is null.</returns>
    public static Task<T[]> ToArrayAsync<T>(this Task<List<T>> self)
        => self.ContinueWith(t => t.Result?.ToArray() ?? []);

    /// <summary>
    /// Converts a Task that returns an IEnumerable to a Task that returns an IEnumerable (identity operation).
    /// </summary>
    /// <param name="self">The Task containing an IEnumerable.</param>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <returns>A Task that, when completed, will contain the same IEnumerable, or null if the original IEnumerable is null.</returns>
    public static Task<IEnumerable<T>> ToEnumerableAsync<T>(this Task<IEnumerable<T>> self)
        => self.ContinueWith(t => t.Result?.AsEnumerable());
    
    /// <summary>
    /// Converts a Task that returns an array to a Task that returns an IEnumerable.
    /// </summary>
    /// <param name="self">The Task containing an array to convert to an IEnumerable.</param>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <returns>A Task that, when completed, will contain an IEnumerable view of the array, or null if the array is null.</returns>
    public static Task<IEnumerable<T>> ToEnumerableAsync<T>(this Task<T[]> self)
        => self.ContinueWith(t => t.Result?.AsEnumerable());
    
    /// <summary>
    /// Converts a Task that returns a List to a Task that returns an IEnumerable.
    /// </summary>
    /// <param name="self">The Task containing a List to convert to an IEnumerable.</param>
    /// <typeparam name="T">The type of elements in the List.</typeparam>
    /// <returns>A Task that, when completed, will contain an IEnumerable view of the List, or null if the List is null.</returns>
    public static Task<IEnumerable<T>> ToEnumerableAsync<T>(this Task<List<T>> self)
        => self.ContinueWith(t => t.Result?.AsEnumerable());
    
    /// <summary>
    /// Converts a Task that returns an IList to a Task that returns an IEnumerable.
    /// </summary>
    /// <param name="self">The Task containing an IList to convert to an IEnumerable.</param>
    /// <typeparam name="T">The type of elements in the IList.</typeparam>
    /// <returns>A Task that, when completed, will contain an IEnumerable view of the IList, or null if the IList is null.</returns>
    public static Task<IEnumerable<T>> ToEnumerableAsync<T>(this Task<IList<T>> self)
        => self.ContinueWith(t => t.Result?.AsEnumerable());
}