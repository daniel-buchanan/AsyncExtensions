using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Common.AsyncExtensions;

public static class StopwatchExtensions
{
    /// <summary>
    /// Execute and time a given method and return a result representing the timing of the provided method.
    /// </summary>
    /// <param name="self">The <see cref="Stopwatch" /> instance to use.</param>
    /// <param name="task">The <see cref="Action"/> or method to time.</param>
    /// <returns>A new <see cref="StopwatchResult"/> representing the timing of the method.</returns>
    public static StopwatchResult Time(this Stopwatch self, Action task)
        => self.TimeAsync(() => { task(); return Task.CompletedTask; }).WaitFor();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <param name="task"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static StopwatchResult<T> Time<T>(this Stopwatch self, Func<T> task)
        => self.TimeAsync(() => Task.FromResult(task())).WaitFor();

    /// <summary>
    /// Execute and time a given async method and return a result representing the timing of the provided method.
    /// </summary>
    /// <param name="self">The <see cref="Stopwatch" /> instance to use.</param>
    /// <param name="task">The async <see cref="Func{Task}"/> or method to time.</param>
    /// <returns>A new <see cref="StopwatchResult"/> representing the timing of the method.</returns>
    public static async Task<StopwatchResult> TimeAsync(this Stopwatch self, Func<Task> task)
    {
        await self.TimeAsync(async () => { await task(); return Task.FromResult(true); });
        return StopwatchResult.FromStopwatch(self, task.Method.Name);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <param name="task"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<StopwatchResult<T>> TimeAsync<T>(this Stopwatch self, Func<Task<T>> task)
    {
        self.Reset();
        self.Start();
        var result = await task();
        self.Stop();
        return StopwatchResult.FromStopwatch(self, task.Method.Name, result);
    }
}