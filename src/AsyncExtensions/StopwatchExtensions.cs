using System;
using System.Diagnostics;

namespace AsyncExtensions;

public static class StopwatchExtensions
{
    public static Stopwatch StartNow(this Stopwatch stopwatch)
    {
        stopwatch.Start();
        return stopwatch;
    }

    public static Stopwatch Time(this Stopwatch self, Action task)
    {
        self.Reset();
        self.Start();
        task();
        self.Stop();
        return self;
    }

    public static T Time<T>(this Stopwatch self, Func<T> task)
    {
        self.Reset();
        self.Start();
        var result = task();
        self.Stop();
        return result;
    }
}