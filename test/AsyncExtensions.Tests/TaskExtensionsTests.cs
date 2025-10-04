using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace Common.AsyncExtensions.Tests;

public class TaskExtensionsTests
{
    [Theory]
    [MemberData(nameof(AwaitableTestCases))]
    public void WaitActuallyWaits(int delay, long minDelay, long maxDelay)
    {
        // Arrange
        var t = () => Task.Delay(delay);
        
        // Act
        var st = new Stopwatch();
        st.Time(() => t().WaitFor());

        // Assert
        st.ElapsedMilliseconds.Should().BeInRange(minDelay, maxDelay);
    }
    
    [Theory]
    [MemberData(nameof(AwaitableResultTestCases))]
    public void WaitForReturnsSuccessfully<T>(int delay, T result, long minDelay, long maxDelay)
    {
        // Arrange
        async Task<T> Method()
        {
            await Task.Delay(delay);
            return result;
        }

        // Act
        var st = new Stopwatch();
        var r = st.Time(() => Method().WaitFor());

        // Assert
        r.ElapsedMilliseconds.Should().BeInRange(minDelay, maxDelay);
        r.Result.Should().Be(result);
    }

    [Fact]
    public void CaptureExceptionIsThrown()
    {
        // Arrange
        async Task AwaitableMethod()
        {
            await Task.Delay(10);
            throw new Exception("hello");
        }
        
        // Act
        var m = () => AwaitableMethod().WaitFor();

        // Assert
        m.Should()
            .Throw<Exception>()
            .And.Message.Should().Be("hello");
    }
    
    [Fact]
    public void CaptureExceptionIsThrownForTyped()
    {
        // Arrange
        async Task<string> AwaitableMethod()
        {
            await Task.Delay(10);
            throw new Exception("hello");
        }
        
        // Act
        var m = () => AwaitableMethod().WaitFor();

        // Assert
        m.Should()
            .Throw<Exception>()
            .And.Message.Should().Be("hello");
    }

    public static TheoryData<int, long, long> AwaitableTestCases =>
        new()
        {
            { 100, 90, 110 },
            { 400, 395, 405 },
            { 5000, 4990, 5010 }
        };

    public static TheoryData<int, object, long, long> AwaitableResultTestCases =>
        new()
        {
            { 100, "hello world", 90, 110 },
            { 400, new[] { "hello", "dangerous", "world" }, 390, 410 },
            { 5000, new { Id = 42, Name = "MeaningOf", Type = typeof(int) }, 4990, 5010 }
        };
}