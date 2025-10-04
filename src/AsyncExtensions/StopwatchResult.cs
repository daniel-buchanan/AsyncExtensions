using System;
using System.Diagnostics;

// ReSharper disable once CheckNamespace
namespace System.Diagnostics;

/// <summary>
/// Result from a <see cref="StopwatchExtensions.Time"/> method.
/// </summary>
public class StopwatchResult
{
    protected StopwatchResult(TimeSpan timeSpan, string signature)
    {
        Elapsed = timeSpan;
        ElapsedMilliseconds = timeSpan.TotalMilliseconds;
        MethodSignature = signature;
    }
    
    /// <summary>Gets the total elapsed time measured by the stopwatch, in milliseconds.</summary>
    /// <returns>A read-only long integer representing the total number of milliseconds measured by the stopwatch.</returns>
    public double ElapsedMilliseconds { get; }
    
    /// <summary>Gets the total elapsed time measured by the stopwatch.</summary>
    /// <returns>A read-only <see cref="T:System.TimeSpan" /> representing the total elapsed time measured by the stopwatch.</returns>
    public TimeSpan Elapsed { get; }
    
    /// <summary>
    /// The signature of the method that was timed.
    /// </summary>
    public string MethodSignature { get; }
    
    /// <summary>
    /// Create a <see cref="StopwatchResult"/> from a <see cref="Stopwatch"/> instance.
    /// </summary>
    /// <param name="stopwatch">The <see cref="Stopwatch"/> instance to use.</param>
    /// <param name="signature">The signature of the method that was timed.</param>
    /// <returns>A new <see cref="StopwatchResult"/> representing the method that was timed.</returns>
    public static StopwatchResult FromStopwatch(Stopwatch stopwatch, string signature) 
        => new(stopwatch.Elapsed, signature);
    
    /// <summary>
    /// Create a <see cref="StopwatchResult{T}"/> from a <see cref="Stopwatch"/> instance.
    /// </summary>
    /// <param name="stopwatch">The <see cref="Stopwatch"/> instance to use.</param>
    /// <param name="signature">The signature of the method that was timed.</param>
    /// <param name="result">The result from the timed method.</param>
    /// <typeparam name="T">The type of the response from the method.</typeparam>
    /// <returns>A new <see cref="StopwatchResult{T}"/> containing the result of the timed method and timing details.</returns>
    public static StopwatchResult<T> FromStopwatch<T>(Stopwatch stopwatch, string signature, T result) 
        => new(stopwatch.Elapsed, signature, result);
}

/// <summary>
/// Represents the result of a method that was timed by a <see cref="Stopwatch"/>.
/// </summary>
/// <typeparam name="T">The type of the result from the timed method.</typeparam>
public class StopwatchResult<T> : StopwatchResult
{
    protected internal StopwatchResult(TimeSpan timeSpan, string signature, T result) : 
        base(timeSpan, signature) 
        => Result = result;

    /// <summary>
    /// The result of the method that was timed.
    /// </summary>
    public T Result { get; }
}