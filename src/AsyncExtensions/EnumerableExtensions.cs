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
    {
        var result = self.WaitFor();
        var converted = result?.ToList() ?? [];
        return Task.FromResult(converted);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Task<List<T>> ToListAsync<T>(this Task<T[]> self)
    {
        var result = self.WaitFor();
        var converted = result?.ToList() ?? [];
        return Task.FromResult(converted);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Task<T[]> ToArrayAsync<T>(this Task<IEnumerable<T>> self)
    {
        var result = self.WaitFor();
        var converted = result?.ToArray() ?? [];
        return Task.FromResult(converted);  
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Task<T[]> ToArrayAsync<T>(this Task<List<T>> self)
    {
        var result = self.WaitFor();
        var converted = result?.ToArray() ?? [];
        return Task.FromResult(converted);  
    }
}