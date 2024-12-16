using System.Diagnostics;
using Xunit;
using FluentAssertions;

namespace AsyncExtensions.Tests;

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
        st.ElapsedMilliseconds.Should().BeInRange(minDelay, maxDelay);
        r.Should().Be(result);
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
            .Throw<CapturedAsyncException>()
            .WithInnerException<Exception>()
            .And.Message.Should().Be("One or more errors occurred. (hello)");
    }

    public static IEnumerable<object[]> AwaitableTestCases
    {
        get
        {
            yield return [100, 90, 110];
            yield return [400, 395, 405];
            yield return [5000, 4990, 5010];
        }
    }
    
    public static IEnumerable<object[]> AwaitableResultTestCases
    {
        get
        {
            yield return [100, "hello world", 90, 110];
            yield return [400, new[] { "hello", "dangerous", "world" }, 395, 405];
            yield return [5000, new { Id = 42, Name = "MeaningOf", Type = typeof(int) }, 4990, 5010];
        }
    }
}