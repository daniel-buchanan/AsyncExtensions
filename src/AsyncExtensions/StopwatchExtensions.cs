using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Common.AsyncExtensions;

public static class StopwatchExtensions
{
    public static Stopwatch Time(this Stopwatch self, Action task)
        => self.TimeAsync(() => { task(); return Task.CompletedTask; }).WaitFor();
    
    public static T Time<T>(this Stopwatch self, Func<T> task)
        => self.TimeAsync(() => Task.FromResult(task())).WaitFor();

    public static async Task<Stopwatch> TimeAsync(this Stopwatch self, Func<Task> task)
    {
        await self.TimeAsync(async () => { await task(); return Task.FromResult(true); });
        return self;
    }
    
    public static async Task<T> TimeAsync<T>(this Stopwatch self, Func<Task<T>> task)
    {
        self.Reset();
        self.Start();
        var result = await task();
        self.Stop();
        return result;
    }
}