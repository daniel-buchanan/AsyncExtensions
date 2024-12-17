using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.AsyncExtensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Task<List<T>> ToListAsync<T>(this Task<IEnumerable<T>> self)
        => self.ContinueWith(t => t.Result?.ToList() ?? []);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Task<List<T>> ToListAsync<T>(this Task<T[]> self)
        => self.ContinueWith(t => t.Result?.ToList() ?? []);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Task<T[]> ToArrayAsync<T>(this Task<IEnumerable<T>> self)
        => self.ContinueWith(t => t.Result?.ToArray() ?? []);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Task<T[]> ToArrayAsync<T>(this Task<List<T>> self)
        => self.ContinueWith(t => t.Result?.ToArray() ?? []);
}