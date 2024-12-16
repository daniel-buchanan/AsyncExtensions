using System;
using System.Threading.Tasks;

namespace Common.AsyncExtensions;

public static class TaskExtensions
{
    private const string ErrorTemplate = "AsyncExtensions.WaitFor captured an exception: {0}";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <exception cref="CapturedAsyncException"></exception>
    public static void WaitFor(this Task self)
    {
        try
        {
            self.Wait();
        }
        catch (Exception e)
        {
            var message = string.Format(ErrorTemplate, e.Message);
            throw new CapturedAsyncException(message, e);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="CapturedAsyncException"></exception>
    public static T WaitFor<T>(this Task<T> self)
    {
        try
        {
            self.Wait();
            return self.Result;
        }
        catch (Exception e)
        {
            var message = string.Format(ErrorTemplate, e.Message);
            throw new CapturedAsyncException(message, e);
        }
    }
}